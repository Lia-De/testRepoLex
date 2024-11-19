
using System.Collections.Generic;

namespace BusinessLogic
{
    public class BusinessLogics
    {
        private static decimal musicVAT = 0.06M;
        private static decimal foodVAT = 0.12M;
        private static decimal alcoholVAT = 0.25M;
        private static decimal calculatedVAT = 0;
        public static decimal ReturnVAT(string typeOfPurchase, decimal priceOfItem )
        {
            switch (typeOfPurchase)
            {
                case "music":
                    calculatedVAT = priceOfItem * musicVAT;
                    return calculatedVAT;
                    break;
                case "food":
                    calculatedVAT = priceOfItem * foodVAT;
                    return calculatedVAT;
                    break;
                case "alcohol":
                    calculatedVAT = priceOfItem * alcoholVAT;
                    return calculatedVAT;
                    break;
                default:
                    return 0;
            }
        }

        public static int MembershipFee (int memberAge, bool premium)
        {
            int payable = 0;
            if (premium)
            {
                payable += 300;
            }
            if (memberAge< 19 || memberAge > 64)
            {
                payable += 2200;
            } else
            {
                payable += 3100;
            }
            return payable;
        }
        public static double MyCalculator(string methodOperator, double valueOne, double valueTwo)
        {
            switch (methodOperator)
            {
                case "divide":
                    return valueOne / valueTwo;
                    break;
                case "multiply":
                    return valueOne * valueTwo;
                    break;
                case "subtract":
                    return valueOne - valueTwo;
                    break;
                case "add":
                    return valueOne + valueTwo;
                    break;
                default:
                    return 0;
            }
        }

        // valit input values are: help, add, delete, edit, find, list
        public static void MenuOptions(string input)
        {
            switch (input)
            {
                case "help":
                    Console.WriteLine("This method should output a screen print when you enter one of the following parameters: help, add, delete, edit, find, list");
                    break;
                case "add":
                    Console.WriteLine("You wanted to add a menu item");
                    break;
                case "delete":
                    Console.WriteLine("Which menu item do you wish to delete?");
                    break;
                case "edit":
                    Console.WriteLine("Now editing menu item");
                    break;
                case "find":
                    Console.WriteLine("I have found the menu item you were looking for");
                    break;
                case "list":
                    Console.WriteLine("These are the menu items I have available: Tea ; Coffee ; Juice");
                    break;
            }
        }

    }
}
