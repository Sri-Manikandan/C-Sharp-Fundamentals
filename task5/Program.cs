using System;
using System.IO;
using System.Linq;


namespace Task5{
    class Program{
        static void Main(string[] args){
            string inputFile  = "input.txt";
            string outputFile = "output.txt";

            try{
                string[] lines = File.ReadAllLines(inputFile);

                int lineCount = lines.Length;
                
                int wordCount = lines.Sum(line => line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length);
                int charCount = lines.Sum(line => line.Length);


                string report = $"Source File : {inputFile}\n"+ $"Lines: {lineCount}\n"+ $"Words: {wordCount}\n"+ $"Characters: {charCount}\n";

                File.WriteAllText(outputFile, report);
                Console.WriteLine(report);

                Console.WriteLine($"Report saved to '{outputFile}'.");
            }
            catch (FileNotFoundException ex){
                Console.WriteLine($"File not found: {ex.FileName}");
            }
            catch (IOException ex){
                Console.WriteLine($"I/O error occurred: {ex.Message}");
            }
        }
    }
}