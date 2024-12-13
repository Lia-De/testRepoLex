using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConcertDemo;

public class BookingAgent
{
    public List<Gig> ConcertList = new List<Gig>();
    public int NumberOfGigs;
    private Dictionary<Venues, int> VenueCapacity = new Dictionary<Venues, int>();
    public BookingAgent()
    {
        // Initialize the venue capacities
        VenueCapacity.Add(Venues.Alfvensalen, 400);
        VenueCapacity.Add(Venues.UniversitetsAulan, 350);
        VenueCapacity.Add(Venues.Fyrishov, 1500);
        VenueCapacity.Add(Venues.UKK, 1120);
        
        // Starting up = read in the concert in the saved file and set the NumberofGigs to the highest ID
        List<Gig> concertList = RestoreList();
        if (concertList != null)
        {
            ConcertList = concertList;
            int highestID = 0;
            foreach (Gig g in ConcertList)
            {
                if (g.GigID > highestID) highestID = g.GigID;
            }
            NumberOfGigs = highestID;
        } else { NumberOfGigs = 0; }
    }

    public Gig BookConcert(string artist, Venues venue, DateTime date)
    {
        ++NumberOfGigs;
        Gig newGig = new Gig(NumberOfGigs, artist, venue, VenueCapacity[venue], date);
        ConcertList.Add(newGig);
        WritePersistantList();
        return newGig;
    }

    public bool DeleteConcert(int gigID)
    {
        Gig gigToCancel = FindListItem(gigID);
        bool result = ConcertList.Remove(gigToCancel);
        WritePersistantList();
        return result;
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

            if (seatsWanted <= (gigToBook.Capacity - gigToBook.Bookings))
            {
                gigToBook.Bookings += seatsWanted;
                
                WritePersistantList();
                return gigToBook.Bookings;
            }
            else
            {
                Console.WriteLine("! There are not enough seats at this gig to accomodate the number of seats wanted. No seats booked");
            }
        }
        catch (ArgumentNullException e)
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
        WritePersistantList();
        return gigToEdit;
    }
    public Gig EditConcert(int gigID, DateTime date)
    {
        Gig gigToEdit = FindListItem(gigID);
        gigToEdit.GigDate = date;
        WritePersistantList();
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
        WritePersistantList(); 
        return gigToEdit;
    }

    public List<int> ValidGigIDs()
    {
        List<int> output = new List<int>();
        foreach (Gig g in ConcertList)
        {
            output.Add(g.GigID);
        }
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

    public static List<Gig> RestoreList()
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
