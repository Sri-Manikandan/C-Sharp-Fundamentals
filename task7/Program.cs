using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task2{
    class DataFetcher{
        public async Task<string> FetchUsersAsync(){
            Console.WriteLine("Users API Starting...");
            await Task.Delay(2000);
            Console.WriteLine("Users API Done!");
            return "Users Data: Alice, Bob, Charlie";
        }
        public async Task<string> FetchOrdersAsync(){
            Console.WriteLine("Orders DB Starting...");
            await Task.Delay(3000);

            Console.WriteLine("Orders DB Done!");
            return "Orders Data: Order_1, Order_2, Order_3";
        }

        public async Task<string> FetchWeatherAsync(){
            Console.WriteLine("Weather API Starting...");
            await Task.Delay(1000);
            Console.WriteLine("Weather API Done!");
            return "Weather Data: Sunny, 32°C";
        }


        public async Task<string> FetchStockAsync(){
            Console.WriteLine("Stock API Starting...");
            await Task.Delay(1500);
            throw new Exception("Stock API is unavailable!");
        }
    }

    class Program{
        static async Task Main(string[] args){
            DataFetcher fetcher = new DataFetcher();
            Console.WriteLine("Fetching data from all sources concurrently\n");

            DateTime start = DateTime.Now;

            Task<string> usersTask   = fetcher.FetchUsersAsync();
            Task<string> ordersTask  = fetcher.FetchOrdersAsync();
            Task<string> weatherTask = fetcher.FetchWeatherAsync();
            Task<string> stockTask   = fetcher.FetchStockAsync();


            List<string> results = new List<string>();
            Task<string>[] allTasks = { usersTask, ordersTask, weatherTask, stockTask };

            await Task.WhenAll(allTasks).ContinueWith(_ => { });

            foreach (var task in allTasks){
                if (task.IsFaulted){
                    Console.WriteLine($"\nERROR: {task.Exception.InnerException.Message}");
                }
                else if (task.IsCompletedSuccessfully){
                    results.Add(task.Result);
                }
            }
            DateTime end = DateTime.Now;

            Console.WriteLine("\nAggregated Results\n");
            foreach (var result in results){
                Console.WriteLine($"  ~ {result}");
            }

            Console.WriteLine($"\nTotal time taken : {(end - start).TotalSeconds:F1}s");
            Console.WriteLine($"Successful tasks : {results.Count}/{allTasks.Length}");
            Console.WriteLine($"Failed tasks     : {allTasks.Length - results.Count}/{allTasks.Length}");
        }
    }
}
