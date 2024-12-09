using ConcertDemo;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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
            "" ;
});

app.Run();
