// See https://aka.ms/new-console-template for more information
/*
 * Make a value-added tax method for a café business. The method should
take a string value indicating one of three product options and a decimal
value representing the price of the product. The method should return the
value added tax (VAT) calculated.
The café on occasions sells music entertainment. The VAT is 6 percent.
The café sells food. The VAT is 12 percent.
The café sells alcohol. The VAT is 25 percent.
 * */

using BusinessLogic;
using System.Net.WebSockets;
// Assignment 1
Console.WriteLine("Business Logic, Assignment week 47 - 1: VAT calculations ");

decimal calculatedVAT = BusinessLogics.ReturnVAT("music", (decimal) 12.14);
Console.WriteLine("calculated VAT on 12.14 for music " + calculatedVAT);

calculatedVAT = BusinessLogics.ReturnVAT("food", (decimal) 12.14);
Console.WriteLine("calculated VAT on 12.14 for food: " + calculatedVAT);

calculatedVAT = BusinessLogics.ReturnVAT("alcohol", (decimal)12.14);
Console.WriteLine("calculated VAT on 12.14 for food: " + calculatedVAT);

// Should return 0, not a defined VAT
calculatedVAT = BusinessLogics.ReturnVAT("drink", (decimal)12.14);
Console.WriteLine("calculated VAT on 12.14 for drink: " + calculatedVAT);



/* 
 * Make a method calculating the price when signing up for a gym
membership. The method should take an int value indicating the age of
the signee and a bool value indicating a wish for premium membership.
Persons below the age of 19 and above the age of 64 pay 2200 for their
membership. All else pay 3100. The premium membership is a straight 300
amount on top of what the signee already will pay. The method should
return the full amount payable for the signee.
 */
Console.WriteLine("Business Logic, Assignment week 47 - 2: Gym membership ");
//  Change the following two parameters to test.
int ageOfMEmber = 73;
bool premium = true;
Console.WriteLine("Membership fee for "+ageOfMEmber+" year old. Premium = "+ premium);
Console.WriteLine(BusinessLogics.MembershipFee(ageOfMEmber, premium));

/*
 * Use a switch statement to make a calculator method that takes a string
value indicating the mathematical operation and two double values as
parameters. The method returns the result of the operation, which should
at least include adding, subtracting, multiplying and dividing.
4.
 */
Console.WriteLine("Business Logic, Assignment week 47 - 3: A Calculator ");
// Change the following three parameters to test. Proper terms for methodOperator are: divide, add, subtract, multiply
string methodOperator = "divide";
double valueOne = 3;
double valueTwo = 4;
double assignment3Result = BusinessLogics.MyCalculator(methodOperator, valueOne, valueTwo);
Console.WriteLine("The result from " + methodOperator + ", " + valueOne + ", " + valueTwo +" is: "+ assignment3Result);

methodOperator = "add";
assignment3Result = BusinessLogics.MyCalculator(methodOperator, valueOne, valueTwo);
Console.WriteLine("The result from " + methodOperator + ", " + valueOne + ", " + valueTwo + " is: " + assignment3Result);

/* 
 * Make a menu options method that takes one of the following options as a
string value parameter:
- help, add, delete, edit, find, list
The method should not return any value, but for the option chosen, print
out a unique and appropriate message using Console.WriteLine().
*/
Console.WriteLine("Business Logic, Assignment week 47 - 4: Menu options");
// Change the following parameter to test
string menuInput = "help";
BusinessLogics.MenuOptions(menuInput);
menuInput = "edit";
BusinessLogics.MenuOptions(menuInput);
menuInput = "list";
BusinessLogics.MenuOptions(menuInput);
