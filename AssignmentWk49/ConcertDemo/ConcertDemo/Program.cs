using ConcertDemo;

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
    
    // Saved to file. Now delete all but one events from runtime, and read from the file,
    jennysBokare.DeleteConcert(1);
    jennysBokare.DeleteConcert(2);
    jennysBokare.DeleteConcert(3);
    jennysBokare.DeleteConcert(4);
    jennysBokare.DeleteConcert(5);

    // Print out the list restored from file, to show it's done.
    List<Gig> restoredGigs = new List<Gig>();
    restoredGigs = BookingAgent.RestoreList();
    foreach (Gig g in restoredGigs)
    {
        g.ShowInfo();
    }

    Console.WriteLine("\n   Welcome to Jenny's Booking Agent. We currently have < " + jennysBokare.ConcertList.Count() + " > Concerts on the books.");
    Console.WriteLine(GetUserInput.ShowMenu);

    GetUserInput.HandleUserInput(jennysBokare);
}