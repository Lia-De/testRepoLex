using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConcertDemo
{
    public class BookingAgent
    {
        public List<Gig> ConcertList = new List<Gig>();
        public int NumberOfGigs;
        private static Dictionary<Venues, int> VenueCapacity = new Dictionary<Venues, int>();
        public BookingAgent()
        {
            NumberOfGigs = 0;
            VenueCapacity.Add(Venues.UKK, 1120);
            VenueCapacity.Add(Venues.Alfvensalen, 400);
            VenueCapacity.Add(Venues.UniversitetsAulan, 350);
            VenueCapacity.Add(Venues.Fyrishov, 1500);
        }
        public void AllConcerts()
        {
            if (ConcertList.Count == 0) Console.WriteLine("    >> There are no Concerts on the books right now.");
            foreach (Gig g in ConcertList) {
                g.ShowInfo();
            }
        }
        public Gig BookConcert(string artist, Venues venue, DateTime date)
        {
            ++NumberOfGigs;
            Gig newGig = new Gig(NumberOfGigs, artist, venue, VenueCapacity[venue], date);
            ConcertList.Add(newGig);
            return newGig;
        }

        public bool DeleteConcert(int gigID)
        {
            Gig gigToCancel = FindListItem(gigID);
            return ConcertList.Remove(gigToCancel);
        }
        public Gig FindListItem(int gigID)
        {
            return ConcertList.Find(gig => gig.GigID.Equals(gigID));
        }

        public int BookSeats(int gigID, int seatsWanted)
        {
            Gig gigToBook;
            try
            {
                gigToBook = FindListItem(gigID);

                Console.Write("       >> Trying to book seats for "+seatsWanted + " people. ");
                if (seatsWanted <= (gigToBook.Capacity - gigToBook.Bookings))
                {
                    gigToBook.Bookings += seatsWanted;
                    Console.WriteLine("Success! ");
                    return gigToBook.Bookings;
                }
                else if (seatsWanted<=0)
                {
                    Console.WriteLine("! You must enter a number greater than 0 to book any seats.");
                }
                else
                {
                    Console.WriteLine("! There are not enough seats at this gig to accomodate the number of seats wanted. No seats booked");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return -1;
        }

        public Gig EditConcert(int gigID, Venues venue) 
        { 
            Gig gigToEdit = FindListItem(gigID);
            int newVenueCap = VenueCapacity[venue];
            int currentBookings = gigToEdit.Bookings;
            if (gigToEdit.Bookings > newVenueCap) Console.WriteLine("! WARNING: Current bookings are more than the new Venue can hold. ");
            gigToEdit.Venue = venue;
            gigToEdit.Capacity = newVenueCap;
            return gigToEdit;
        }
        public Gig EditConcert(int gigID, DateTime date)
        {
            Gig gigToEdit = FindListItem(gigID);
            gigToEdit.GigDate = date;
            return gigToEdit;
        }
        public Gig EditConcert(int gigID, int capacity)
        {
            Gig gigToEdit = FindListItem(gigID);

            if (capacity <= gigToEdit.Bookings)
            {
                Console.WriteLine("! There are currently more bookings than the new capacity. You may not change max now.");
            }
            else if (capacity <0 )
            {
                Console.WriteLine("! You may not have negative number of seats.");
            } else 
            {
                gigToEdit.Capacity = capacity;
                Console.WriteLine("    >> Capacity updated to " + capacity);
            }
            return gigToEdit;

        }

        public string ValidGigIDs()
        {
            string output = "( ";
            foreach ( Gig g in ConcertList)
            {
                output += g.GigID + ",";
            }
            output = output.Trim(',') + " )";
            return output;
        }

        public void WritePersistantList()
        {
            using (StreamWriter writer = new StreamWriter("ConcertList.txt"))
            {
                foreach (Gig gig in ConcertList)
                {
                    writer.WriteLine(gig.GigID);
                    writer.WriteLine(gig.Venue);
                    writer.WriteLine(gig.Artist);
                    writer.WriteLine(gig.Capacity);
                    writer.WriteLine(gig.Bookings);
                    writer.WriteLine(gig.GigDate);
                }
            }
        }

        public List<Gig> RestoreList()
        {
            List<Gig> restoredList = new List<Gig>();

            using (StreamReader reader = new StreamReader("ConcertList.txt"))
            {
                while (reader.Peek() > -1)
                {
                    Gig restoredGig = new Gig();
                    restoredGig.GigID = int.Parse(reader.ReadLine());
                    restoredGig.Venue = (Venues)Enum.Parse(typeof(Venues), reader.ReadLine());
                    restoredGig.Artist = reader.ReadLine();
                    restoredGig.Capacity = int.Parse(reader.ReadLine());
                    restoredGig.Bookings = int.Parse(reader.ReadLine());
                    restoredGig.GigDate = DateTime.Parse(reader.ReadLine());

                    restoredList.Add(restoredGig);
                }
            }

            return restoredList;
        }


    }
}
