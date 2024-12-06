using System.ComponentModel.Design;

namespace ConcertDemo;

public class GetUserInput
{
    public static string ShowMenu = ">> Options 1 = Book seats | 2 = Delete Concert | 3 = Edit Concert | 4 = Add Concert | 0 = Exit  |  9 = List all";

    public static int GetNumber()
    {
        string userInput = "";
        int actualNumber = -1;
        bool wrongContent = true;
        while (wrongContent)
        {
            userInput = Console.ReadLine();
            try
            {
                actualNumber = int.Parse(userInput);
                wrongContent = false;
            }
            catch (FormatException)
            {
                //Console.WriteLine(e.Message);
                Console.WriteLine("! You must enter a number.");
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        return actualNumber;
    }

    public static string GetArtistName()
    {
        string userInput = "";
        string artistName = "";
        bool wrongContent = true;
        while (wrongContent)
        {
            userInput = Console.ReadLine();
            try
            {
                bool containsLetter = userInput.Any(char.IsLetter);
                if (containsLetter)
                {
                    artistName = userInput.Substring(0);
                    wrongContent = false;
                } else
                {
                    Console.Write("! Please enter an artist name containing some letters: ");
                }
            }
            catch (ArgumentNullException)
            {
                Console.Write("! You must enter an artist name containting some letters.");
            }
        }
        return artistName;
    }

    public static Venues GetVenueFromString()
    {
        string input = "";
        Venues newVenue = new Venues();
        bool wrongContent = true;
        while (wrongContent)
        {
            input = Console.ReadLine();
            try
            {
                newVenue = (Venues)Enum.Parse(typeof(Venues), input);
                wrongContent = false;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException)
            {
                Console.Write("! Not a venue. Try again: ");
            }
        }
        return newVenue;
    }

    public static DateTime GetDate()
    {
        DateTime newDate= DateTime.Now;
        int actualNumber=0;
        string userInput = "";
        int year = 0;
        int month = 0;
        int day = 0;
        int hour = 0;
        bool wrongContent = true;
        Console.Write("   >> YEAR (4 digits): ");

        while (wrongContent)
        {
            userInput = Console.ReadLine();
            if (userInput.Length == 4)
            {
                try
                {
                    actualNumber = int.Parse(userInput);
                    wrongContent = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("! You must enter a number.");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
            } else Console.Write("Enter a 4 digit Year: ");
        }
        year = actualNumber;
        wrongContent = true;
        Console.Write("   >> Month (2 digits): ");
        while (wrongContent)
        {
            userInput = Console.ReadLine();
            if (userInput.Length == 2)
            {
                try
                {
                    actualNumber = int.Parse(userInput);
                    wrongContent = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("! You must enter a number.");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
            } else Console.Write("Enter a 2 digit month: "); 
        }
        month = actualNumber;
        wrongContent = true;
        Console.Write("   >> Day (2 digits): ");
        while (wrongContent)
        {
            userInput = Console.ReadLine();
            if (userInput.Length == 2)
            {
                try
                {
                    actualNumber = int.Parse(userInput);
                    wrongContent = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("! You must enter a number.");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
            } else Console.Write("! Enter a 2 digit day: "); 
        }
        day = actualNumber;
        wrongContent = true;
        Console.Write("   >> Hour (2 digits): ");
        while (wrongContent)
        {
            userInput = Console.ReadLine();
            if (userInput.Length == 2)
            {
                try
                {
                    actualNumber = int.Parse(userInput);
                    wrongContent = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("! You must enter a number.");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
            }  else Console.Write("Enter a 2 digit hour: ");
            hour = actualNumber;
        }
        newDate = new DateTime(year, month, day, hour, 0, 0); 

        return newDate;
    }
    public static void PrintVenues()
    {
        foreach (Venues v in Enum.GetValues(typeof(Venues)))
        {
            Console.WriteLine("  "+v);
        }
    }

    public static void HandleUserInput(BookingAgent jennysBokare)
    {
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
                    catch (NullReferenceException)
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
                    if (jennysBokare.DeleteConcert(deleteID)) Console.WriteLine("Deleted concert with ID: " + deleteID);
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
                            Console.WriteLine("\n   >> EDIT Step 3. Current venue is: " + gigToEdit.Venue);
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
                            DateTime newDate = GetUserInput.GetDate();
                            try
                            {
                                jennysBokare.EditConcert(editID, newDate);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("! Date out of range");
                            }
                            Console.WriteLine("   >> Date changed.");

                        }
                        else if (fieldToEdit == 3)
                        {
                            // changing capacity
                            Console.WriteLine("\n   >> EDIT Step 3. Current capacity is: " + gigToEdit.Capacity);
                            Console.Write("   Type in new max capacity: ");
                            int newCap = GetUserInput.GetNumber();
                            jennysBokare.EditConcert(editID, newCap);

                        }
                        else
                        {
                            Console.WriteLine("! Not a valid option");
                        }
                    }
                    catch (NullReferenceException)
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

                    DateTime gigDate = GetUserInput.GetDate();

                    try
                    {
                        Gig newGig = jennysBokare.BookConcert(inputArtist, venue, gigDate);
                        newGig.ShowInfo();
                        Console.WriteLine("   >> New Concert Booked.");
                    }
                    catch (ArgumentOutOfRangeException)
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


}
