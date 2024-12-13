namespace ConcertDemo;

public class Gig
{
    public int GigID { get; set; }
    public Venues Venue { get; set; }
    public int Capacity { get; set; }
    public int Bookings { get; set; }
    public string Artist { get; set; }
    public DateTime GigDate { get; set; }


   public Gig () { }
   
    public Gig(int id, string artist, Venues venue, int capacity, DateTime date)
    {
        GigID = id;
        Venue = venue;
        Artist = artist;
        Capacity = capacity;
        GigDate = date;
        Bookings = 0;
    }
    public Gig(int id, string artist, Venues venue, int capacity, DateTime date, int bookings)
    {
        GigID = id;
        Venue = venue;
        Artist = artist;
        Capacity = capacity;
        GigDate = date;
        Bookings = bookings;
    }

    public void ShowInfo()
    {
        Console.WriteLine("Gig " + GigID + ": '" + Artist + "' playing at " + Venue + ". On: " + GigDate);
        Console.WriteLine("    Total seats: " + Capacity + " Currently booked: " + Bookings);
    }
    public override string ToString()
    {
        return $"{GigID}: {Artist} playing {Venue} on {GigDate} Booked {Bookings}/{Capacity}";
    }
}