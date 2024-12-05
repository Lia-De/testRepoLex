using ConcertDemo;
using System.Collections.Concurrent;

UseBookingAgent();
void UseBookingAgent ()
{
    BookingAgent jennysBokare = new BookingAgent();

    jennysBokare.BookConcert("Orphei drängar", Venues.Alfvensalen, new DateTime(2024, 12, 23, 16, 0, 0));
    jennysBokare.BookConcert("Russel Howard", Venues.UKK, new DateTime(2024, 12, 24, 16, 0, 0));
    jennysBokare.BookConcert("Orphei drängar", Venues.Alfvensalen, new DateTime(2024, 12, 25, 16, 0, 0));
    jennysBokare.BookConcert("TuppKvartetten", Venues.UniversitetsAulan, new DateTime(2024, 12, 26, 16, 0, 0));
    jennysBokare.BookConcert("Euskefeurat", Venues.Fyrishov, new DateTime(2025, 1, 26, 16, 0, 0));
    jennysBokare.BookConcert("TuppKvartetten", Venues.UniversitetsAulan, new DateTime(2025, 1, 10, 16, 0, 0));

    // Write these concerts to file for funsies.
    jennysBokare.WritePersistantList();
    // jennysBokare.AllConcerts();
    Console.WriteLine("Saved to file. Now delete all but one events from runtime, and read from the file" );
    jennysBokare.DeleteConcert(1);
    jennysBokare.DeleteConcert(2);
    jennysBokare.DeleteConcert(3);
    jennysBokare.DeleteConcert(4);
    jennysBokare.DeleteConcert(5);



    List<Gig> restoredGigs = new List<Gig>();
    restoredGigs = jennysBokare.RestoreList();
    foreach (Gig g in restoredGigs)
    {
        g.ShowInfo();
    }

    Console.WriteLine("Welcome to Jennys Booking Agent. We currently have < " + jennysBokare.ConcertList.Count() + " > Concerts on the books.");
    Console.WriteLine(GetUserInput.ShowMenu);

    int menuOption = GetUserInput.GetNumber();

    while (menuOption > 0)
    {
        switch (menuOption)
        {
            case 1:
                // book seats
                Console.WriteLine("\n   >> BOOK Step 1: Type in the id of the Concert you want to book seats for: ");
                Console.WriteLine("   >> Valid IDs: " + jennysBokare.ValidGigIDs());
                Console.Write("   >> Concert ID: ");
                int bookingID = GetUserInput.GetNumber();
                Gig gigToBook;
                try
                {
                    gigToBook = jennysBokare.FindListItem(bookingID);
                    int cap = gigToBook.Capacity;
                    int booked = gigToBook.Bookings;
                    gigToBook.ShowInfo();
                    Console.WriteLine("   >> BOOK Step 2. There are a total of " + cap + " seats, and currently " + booked + " booked.");
                    Console.Write("   >> Number of seats you want to book: ");
                    int seatsToBook = GetUserInput.GetNumber();
                    if (seatsToBook <= 0)
                    {
                        Console.WriteLine("! You must enter a number of seats bigger than 0. ");
                        break;
                    }
                        jennysBokare.BookSeats(bookingID, seatsToBook);

                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("! That is not a valid Concert");
                }
                break;
            case 2:
                // delete
                Console.WriteLine("\n   >> DELETE. Type in the id of the Concert to delete. ");
                Console.WriteLine("   >> Valid IDs: " + jennysBokare.ValidGigIDs());
                Console.Write("   >> Concert ID: ");
                int deleteID = GetUserInput.GetNumber();
                if (jennysBokare.DeleteConcert(deleteID))  Console.WriteLine("Deleted concert with ID: "+ deleteID);
                else Console.WriteLine("! Not a valid concert to delete");
                break;
            case 3:
                // Edit 
                Console.WriteLine("\n   >> EDIT Step 1. Type in the id of the concert to edit and press enter.");
                Console.WriteLine("   >> Valid IDs: " + jennysBokare.ValidGigIDs());
                Console.Write("   >> Concert ID: ");
                int editID = GetUserInput.GetNumber();
                Gig gigToEdit;
                try
                {
                    gigToEdit = jennysBokare.FindListItem(editID);
                    gigToEdit.ShowInfo();
                    Console.WriteLine("\n   >> EDIT Step 2. Choose which field to edit 1 = venue, 2 = date, 3 = capacity");
                    Console.Write("   >> : ");
                    int fieldToEdit = GetUserInput.GetNumber();
                    if (fieldToEdit == 1)
                    {
                        Console.WriteLine("\n   >> EDIT Step 3. Current venue is: "+gigToEdit.Venue);
                        Console.WriteLine("    >> Choose new Venue from these options: ");
                        GetUserInput.PrintVenues();
                        Console.Write("    >>: ");
                        Venues newVenue = GetUserInput.GetVenueFromString();
                        jennysBokare.EditConcert(editID, newVenue);
                        Console.WriteLine("   >> Venue changed.");
                    }
                    else if (fieldToEdit == 2)
                    {
                        // changing date
                        int editYear, editMonth, editDay, editHour;
                        Console.WriteLine("   >> Date format: YYYY, MM, DD, HH ");
                        Console.Write("   >> YEAR (4 digits): ");
                        editYear = GetUserInput.GetNumber();
                        Console.Write("   >> Month (2 digits): ");
                        editMonth = GetUserInput.GetNumber();
                        Console.Write("   >> Day (2 digits): ");
                        editDay = GetUserInput.GetNumber();
                        Console.Write("   >> Hour (2 digits): ");
                        editHour = GetUserInput.GetNumber();
                        try
                        {
                            jennysBokare.EditConcert(editID, new DateTime(editYear, editMonth, editDay, editHour, 0, 0));
                        } catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("! Date out of range");

                        }
                        Console.WriteLine("   >> Date changed.");

                    }
                    else if (fieldToEdit == 3)
                    {
                        // changing capacity
                        Console.WriteLine("\n   >> EDIT Step 3. Current capacity is: "+gigToEdit.Capacity);
                        Console.Write("   Type in new max capacity: ");
                        int newCap = GetUserInput.GetNumber();
                        jennysBokare.EditConcert(editID, newCap);

                    } else 
                    {
                        Console.WriteLine("! Not a valid option");
                    }
                } catch (NullReferenceException)
                {
                    Console.WriteLine("! That is not a valid Concert");
                }
                break;
            case 4:
                // Add 
                Console.WriteLine("\n   >> ADD new Concert. You must input Artist, Venue and Time.");
                Console.Write("   >> Artist: ");
                string inputArtist = "";
                // inputArtist = Console.ReadLine();
                inputArtist = GetUserInput.GetArtistName();

                Console.WriteLine("  Venue options are: ");
                GetUserInput.PrintVenues();
                Console.Write("   >> Choose Venue: ");
                Venues venue = GetUserInput.GetVenueFromString();

                int inputYear, inputMonth, inputDay, inputHour;
                Console.WriteLine("   >> Date format: YYYY, MM, DD, HH ");
                Console.Write("   >> YEAR (4 digits): ");
                inputYear = GetUserInput.GetNumber();
                Console.Write("   >> Month (2 digits): ");
                inputMonth = GetUserInput.GetNumber();
                Console.Write("   >> Day (2 digits): ");
                inputDay = GetUserInput.GetNumber();
                Console.Write("   >> Hour (2 digits): ");
                inputHour = GetUserInput.GetNumber();


                try
                {
                    Gig newGig = jennysBokare.BookConcert(inputArtist, venue, new DateTime(inputYear, inputMonth, inputDay, inputHour, 0, 0));
                    newGig.ShowInfo();
                    Console.WriteLine("   >> New Concert Booked.");
                } catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("! Date out of range.");
                }
               
                break;
            case 9:
                jennysBokare.AllConcerts();
                break;
            default:
                Console.WriteLine("! Not an option");
                break;
        }
        Console.WriteLine(GetUserInput.ShowMenu);
        menuOption = GetUserInput.GetNumber();
    }

}