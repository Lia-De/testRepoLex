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

    public static void PrintVenues()
    {
        foreach (Venues v in Enum.GetValues(typeof(Venues)))
        {
            Console.WriteLine("  "+v);
        }
    }
}
