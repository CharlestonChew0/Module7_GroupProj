using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module7_GroupProj
{
    internal class Program
    {
        // Dictionary that stores keys with multiple values (each key can have a list of values)
        public static Dictionary<string, List<string>> numberNames = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            string switchString = ""; // Set switch string to empty for initialization

            while (switchString != "Q") // This while loop will allow us to keep inputting user commands until the input = Q
            {
                Console.WriteLine("Enter a number 1-4 to add as a key and value. Q to quit, S to sort, R to remove, A to add new pair:");
                switchString = Console.ReadLine().ToUpper();

                switch (switchString)
                {
                    case "R": // If they type "R", it will wait for a number from the user to use as the key to remove
                        Console.WriteLine("Enter a key to remove");
                        numberNames.Remove(Console.ReadLine());
                        break;

                    //=============================
                    // ADD NEW KEY AND VALUE
                    //=============================
                    case "A": // Creates a new Key and Value based on user input
                        Console.Write("Enter key: ");
                        string key = Console.ReadLine(); // First input is the key string

                        Console.Write("Enter value: ");
                        string value = Console.ReadLine(); // Second input is the value string

                        // Create a new key with a list containing the entered value
                        numberNames[key] = new List<string>{ value }; 

                        Console.WriteLine($"Added: {key} -> {value}");
                        break;

                    case "S": 
                        Console.WriteLine("Dictionary sorted by key:");

                        foreach (var kvp in numberNames.OrderBy(k => k.Key)) // Goes over every key and sorts by numerical value
                        {
                            Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                        }
                        break;

                    // ==============================
                    // DISPLAY DICTIONARY CONTENTS
                    // ==============================
                    case "D":
                        Console.WriteLine("Dictionary Contents:");

                        foreach (var kvp in numberNames)
                        {
                            Console.WriteLine($"{kvp.Key} -> {string.Join(", ", kvp.Value)}");
                        }
                        break;

                    case "Q":
                        Console.WriteLine("Exiting program..."); // Typing Q does nothing in the switch, but when the loop checks the value it will end the program
                        break;

                        // Everything past this point is just number switches the user can add to the dictionary

                    case "1":
                        numberNames["1"] = new List<string>{ "One" }; // Predefined Key-value pairs (populate dictionary with initial data)
                        Console.WriteLine("Added: 1(Key) -> One(Value)");
                        break;

                    case "2":
                        numberNames["2"] = new List<string>{ "Two" };
                        Console.WriteLine("Added: 2(Key) -> Two(Value)");
                        break;

                    case "3":
                        numberNames["3"] = new List<string>{ "Three" };
                        Console.WriteLine("Added: 3(Key) -> Three(Value)");
                        break;

                    case "4":
                        numberNames["4"] = new List<string>{ "Four" };
                        Console.WriteLine("Added: 4(Key) -> Four(Value)");
                        break;



                    default: // Default will catch any switch that isn't recognized and funnel it here
                        Console.WriteLine("Input unrecognized, try again");
                        break;
                }
            }
        }
    }
}
