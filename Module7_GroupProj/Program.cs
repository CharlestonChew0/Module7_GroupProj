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
            // List string ensures single key can store multiple entries

            while (switchString != "Q") // This while loop will allow us to keep inputting user commands until the input = Q
            {
                //==================
                // MENU DISPLAY
                //==================
                Console.WriteLine("\n==== MENU ====");
                Console.WriteLine("1-4 = Add preset values");
                Console.WriteLine("A = Add new Key/Value");
                Console.WriteLine("R = Remove key");
                Console.WriteLine("S = Sort keys");
                Console.WriteLine("D = Display dictionary");
                Console.WriteLine("V = Add value to existing key");
                Console.WriteLine("Q = Quit");
                Console.Write("Enter your choice: ");
                
                switchString = Console.ReadLine().ToUpper();

                switch (switchString)
                {
                    case "R": // Wait for a key from the user to remove
                        Console.WriteLine("Enter a key to remove: ");
                        string keyToRemove = Console.ReadLine();
                        if (numberNames.Remove(keyToRemove)) 
                        {
                            Console.WriteLine("Key removed successfully.");
                        }
                        else 
                        {
                            Console.WriteLine("Key not found. Nothing removed.");
                        }
                        break;

                    case "A": // Creates a new Key and Value based on user input
                        Console.Write("Enter key: ");
                        string key = Console.ReadLine(); 

                        Console.Write("Enter value: ");
                        string value = Console.ReadLine(); 

                        // --- FIX IMPLEMENTED HERE ---
                        // If the key already exists, then its added to the list rather than intializing a new list
                        if (numberNames.ContainsKey(key)) 
                        {
                            numberNames[key].Add(value);
                        }
                        else
                        {
                            numberNames[key] = new List<string> { value };
                        }

                        Console.WriteLine($"Processed: {key} -> {value}");
                        break;

                    case "S": // OrderBy sorts keys to display for the user
                        Console.WriteLine("Dictionary sorted by key:");
                        
                        // Goes over every key and sorts by alphabetical/numerical value
                        foreach (var kvp in numberNames.OrderBy(k => k.Key)) 
                        {
                            Console.WriteLine($"{kvp.Key} -> {string.Join(", ", kvp.Value)}");
                        } 
                        // string.Join ensures program won't just say "System.Collections.Generic.List'1" 
                        break;

                    case "D": // DISPLAY DICTIONARY CONTENTS
                        Console.WriteLine("Dictionary Contents:");
                        foreach (var kvp in numberNames)
                        {
                            Console.WriteLine($"{kvp.Key} -> {string.Join(", ", kvp.Value)}");
                        }
                        break;

                    case "V": // ADD A VALUE TO AN EXISTING KEY (Requirement E)
                        Console.Write("Enter existing key: ");
                        string existingKey = Console.ReadLine();

                        if (numberNames.ContainsKey(existingKey))
                        {
                            Console.Write("Enter value to add: ");
                            string newValue = Console.ReadLine();

                            // .Add() appends the new item to the list of the existing key
                            numberNames[existingKey].Add(newValue);
                            Console.WriteLine("Value added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Key not found.");
                        }
                        break;

                    case "Q":
                        Console.WriteLine("Exiting program...");
                        break;

                    // Presets 1-4: Populate dictionary with initial data
                    case "1":
                        AddPreset("1", "One");
                        break;
                    case "2":
                        AddPreset("2", "Two");
                        break;
                    case "3":
                        AddPreset("3", "Three");
                        break;
                    case "4":
                        AddPreset("4", "Four");
                        break;

                    default:
                        Console.WriteLine("Input unrecognized, try again");
                        break;
                }
            }
        }

        // Helper method to keep preset logic clean and prevent overwriting
        static void AddPreset(string k, string v)
        {
            if (!numberNames.ContainsKey(k))
            {
                numberNames[k] = new List<string> { v };
                Console.WriteLine($"Added: {k}(Key) -> {v}(Value)");
            }
            else if (!numberNames[k].Contains(v))
            {
                numberNames[k].Add(v);
                Console.WriteLine($"Appended: {k}(Key) -> {v}(Value)");
            }
            else
            {
                Console.WriteLine("Preset already exists in this key.");
            }
        }
    }
}
