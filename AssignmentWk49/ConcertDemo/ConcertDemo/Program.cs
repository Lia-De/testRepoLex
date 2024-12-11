using ConcertDemo;

 UseBookingAgent();
void UseBookingAgent ()
{
    BookingAgent jennysBokare = new BookingAgent();

    Console.WriteLine($"\n   Welcome to Jenny's Booking Agent. We currently have < {jennysBokare.ConcertList.Count()} > Concerts on the books.");
    Console.WriteLine(GetUserInput.ShowMenu);
    GetUserInput.HandleUserInput(jennysBokare);
}