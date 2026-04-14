using System;


namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive integer: ");
            int input = Convert.ToInt32(Console.ReadLine());

            if (input < 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }


            long factorial = CalculateFactorial(input);

            Console.WriteLine($"Factorial of {input} is {factorial}");
        }
        
        static long CalculateFactorial(int n)
        {
            long result = 1;

            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
