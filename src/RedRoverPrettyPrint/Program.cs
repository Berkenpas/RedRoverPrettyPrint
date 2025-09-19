using RedRoverPrettyPrint.Core;
using RedRoverPrettyPrint.Data;

namespace RedRoverPrettyPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = ExampleData.Examples;
            
            Console.WriteLine("Welcome to the Red Rover Pretty Print! We print things pretty, formatted, and clean!");
            Console.WriteLine("We hope you enjoy your time printing pretty!\n");

            bool continueRunning = true;
            while (continueRunning)
            {
                Console.WriteLine("Would you like some provided examples, or would you like to enter your own data to be pretty printed? (Type 'example' or 'own')");
                var choice = Console.ReadLine();
                
                if (choice?.ToLower() == "own")
                {
                    ProcessUserInput();
                }
                else
                {
                    ProcessExampleData(dict);
                }

                Console.WriteLine("\nWould you like to continue? (Type 'Y' to continue or 'N' to exit)");
                var continueChoice = Console.ReadLine();
                continueRunning = continueChoice?.ToLower() == "y" || continueChoice?.ToLower() == "yes";
                
                if (continueRunning)
                {
                    Console.WriteLine("\n \n \n");
                }
            }
            
            Console.WriteLine("\nThank you for using Red Rover Pretty Print! Goodbye!");
        }

        private static void ProcessUserInput()
        {
            string? userInput = "";
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Please enter your data string to be printed in a pretty way, all as one line please:");
                userInput = Console.ReadLine();
            }

            Console.WriteLine("Would you like to alphabetize the properties? (Type 'Y' or 'N')");
            var sortChoice = Console.ReadLine();
            bool shouldSort = sortChoice?.ToLower() == "y" || sortChoice?.ToLower() == "yes";

            Console.WriteLine("Printing pretty...\n");
            Console.WriteLine($"{TreeStringParser.Parse(userInput, shouldSort)}\n");
        }

        private static void ProcessExampleData(Dictionary<string, string> dict)
        {
            Console.WriteLine("Would you like to alphabetize the properties? (Type 'Y' or 'N')");
            var sortChoice = Console.ReadLine();
            bool shouldSort = sortChoice?.ToLower() == "y" || sortChoice?.ToLower() == "yes";

            Console.WriteLine("Here are the provided examples of pretty printing:");
            foreach (var kvp in dict)
            {
                Console.WriteLine($"\n{kvp.Key}:");
                Console.WriteLine($"{TreeStringParser.Parse(kvp.Value, shouldSort)}");
            }
        }
    }
}