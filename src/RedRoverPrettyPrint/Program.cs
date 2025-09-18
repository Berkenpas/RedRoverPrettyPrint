using RedRoverPrettyPrint.Utility;
using System.Text.Json;

namespace RedRoverPrettyPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var jsonString = File.ReadAllText("ExampleData/examples.json");
            var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);

            Console.WriteLine("Welcome to the Red Rover Pretty Print! We print things pretty, formatted, and clean!\nWe hope you enjoy your time printing pretty!\n");

            //Perhaps make this loop
            Console.WriteLine("Would you like some provided examples, or would you line to enter your own data to be pretty printed? (Type 'example' or 'own')");
            var choice = Console.ReadLine();
            if(choice?.ToLower() == "own")
            {
                string? userInput = "";
                while (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Please enter your data string to be printed in a pretty way, all as one line please:");
                    userInput = Console.ReadLine();
                }

                Console.WriteLine("Printing pretty...\n");
                Console.WriteLine($"{FormaterUtility.PrettyPrint(userInput)}\n");
                Console.WriteLine($"Would you like to to alphabatize the properties? (Type 'Y' or 'N')");
                
            }
            else
            {
                Console.WriteLine("Here is a provided example of pretty printing:");
                foreach (var kvp in dict)
                {
                    Console.WriteLine($"{kvp.Key}");
                    Console.WriteLine($"{FormaterUtility.PrettyPrint(kvp.Value)}");
                }
            }

        }
    }
}
