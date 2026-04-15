using System;
using System.Reflection;

namespace task9{
    [AttributeUsage(AttributeTargets.Method)]
    class RunnableAttribute : Attribute{
        public string Description { get; }
        public RunnableAttribute(string description = "No description"){

            Description = description;
        }
    }


    class MathOperations{
        [Runnable("Adds two numbers")]
        public void Add(){
            Console.WriteLine($"Result: 10 + 5 = {10 + 5}");
        }
        [Runnable("Multiplies two numbers")]
        public void Multiply(){
            Console.WriteLine($"Result: 10 x 5 = {10 * 5}");
        }

        public void Divide(){  // No attribute will be ignored
            Console.WriteLine("This won't run.");
        }
    }
    class StringOperations{
        [Runnable("Converts text to uppercase")]
        public void ToUpper(){
            Console.WriteLine($"Result: {"hello"} → {"hello".ToUpper()}");
        }

        [Runnable("Reverses a string")]
        public void Reverse(){
            string word = "CSharp";
            char[] chars = word.ToCharArray();

            Array.Reverse(chars);
            Console.WriteLine($"Result: {word} → {new string(chars)}");
        }
    }

    class SystemInfo{
        [Runnable("Displays current date and time")]
        public void ShowDateTime(){
            Console.WriteLine($"Result: {DateTime.Now:dd-MM-yyyy  HH:mm:ss}");
        }
        public void HiddenMethod(){  // No attribute will be ignored
            Console.WriteLine("This won't run either.");
        }
    }


    class Program{
        static void Main(string[] args){
            Console.WriteLine("Scanning Assembly for [Runnable] Methods\n");
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[]   types    = assembly.GetTypes();

            int totalFound = 0;

            foreach (Type type in types){
                MethodInfo[] methods = type.GetMethods();
                foreach (MethodInfo method in methods){
                    RunnableAttribute attr = method.GetCustomAttribute<RunnableAttribute>();
                    if (attr == null) continue;

                    totalFound++;
                    Console.WriteLine($"[{type.Name}] → {method.Name}()");

                    Console.WriteLine($"Description : {attr.Description}");

                    Console.WriteLine($"Output:");

                    object instance = Activator.CreateInstance(type);
                    method.Invoke(instance, null);
                    Console.WriteLine();
                }
            }
            
            Console.WriteLine($"Done. {totalFound} methods discovered and executed.");
        }
    }
}
