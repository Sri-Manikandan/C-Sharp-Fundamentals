using System;
using System.Collections.Generic;


namespace Task3{
    class Program{
        static List<string> items = new List<string>();

        static void Main(string[] args){
            bool running = true;

            while (running){
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Display All Items");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine().Trim();

                switch (choice){
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        RemoveItem();
                        break;
                    case "3":
                        DisplayItems();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }


        static void AddItem(){
            Console.Write("Enter item to add: ");
            string input = Console.ReadLine().Trim().ToUpper();

            if (string.IsNullOrEmpty(input)){
                Console.WriteLine("Item cannot be empty.");
                return;
            }
            items.Add(input);
            Console.WriteLine($"'{input}' added successfully.");
        }

        static void RemoveItem(){
            if (items.Count == 0){
                Console.WriteLine("List is empty. Nothing to remove.");
                return;
            }

            DisplayItems();
            Console.Write("Enter item to remove: ");
            string input = Console.ReadLine().Trim().ToUpper();

            if (items.Remove(input))
                Console.WriteLine($"'{input}' removed successfully.");
            else
                Console.WriteLine($"'{input}' not found in the list.");
        }
        static void DisplayItems(){
            if (items.Count == 0){
                Console.WriteLine("List is empty.");
                return;
            }

            Console.WriteLine("\nItems:");

            for (int i = 0; i < items.Count; i++){
                Console.WriteLine($"{i + 1}. {items[i]}");
            }
            Console.WriteLine();
        }
    }
}

