using ConcertDemo;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Connected from the frontend, a html page. Connected to this API localhost:[port]
// In order to not stop all other loading we have to use >> async << HttpRequest, and 
// save the data using >> await << in the storing of form.
app.MapPost("/addconcert", async (HttpRequest request) =>
{
    var content = await request.ReadFormAsync();

    string artist = content["artist"].ToString();
    Venues venue = (Venues)Enum.Parse(typeof(Venues), content["venue"].ToString());
    DateTime concertDate;
    try
    {
        concertDate = DateTime.Parse(content["date"].ToString());
    }
    catch (FormatException)
    {
        concertDate = DateTime.Now;
    }

    BookingAgent myBooker = new BookingAgent();
    myBooker.BookConcert(artist, venue, concertDate);
    string allConcerts = "\n";
    foreach (Gig gig in myBooker.ConcertList)
    {
        allConcerts += gig.ToString() + "\n";
    }

    return $"Form submitted to add {artist} playing at {venue} on {concertDate}." +
    $" We currently have {myBooker.ConcertList.Count()} Concerts booked.\n" +
    $"{allConcerts}";
});

app.MapGet("/guess/{number}", (int number) =>
{
    int numberToGuess = 42;
    if (number >  numberToGuess) { return $"The number you entered: {number} was too high."; }
    else if (number < numberToGuess) { return $"The number you entered: {number} was too low"; }
    else { return $"Correct! {number} was it! "; }
});

app.MapGet("/collection", () =>
{
    List<Gig> restoredGigs = new List<Gig>();
    restoredGigs = BookingAgent.RestoreList(); // needs the ConcertList.txt in the same folder
    string jsonResponse = JsonSerializer.Serialize(restoredGigs);

    List<Gig> testGigs = JsonSerializer.Deserialize<List<Gig>>(jsonResponse);
    
    foreach (Gig g in testGigs)
    {
        jsonResponse +="\n"+ g.Artist + " @ " + g.Venue;
    }
    return jsonResponse;
});

app.MapGet("/optional/{input}", (string input) =>
{
    input = input.Trim();
    char[] inputArray = input.ToCharArray();
    string result = "The reverse of your input is: ";
    for (int i = inputArray.Length; i > 0; i-- )
    {
        result += inputArray[i-1];
    }
    return result;
} );

app.MapGet("/", () => {
    return $"Try /guess/x where x is a number between 1 and 100\n" +
            "Or try /collection \n" + 
            "Or try /optional/{your string here}" ;
});

app.Run();
