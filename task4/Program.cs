using System;
using System.Collections.Generic;
using System.Linq;

namespace task4{
    class Student{
        public string Name;
        public int Grade;
        public int Age;

        public Student(string name, int grade, int age){
            Name = name;
            Grade = grade;
            Age = age;
        }
    }

    class Program{
        public static void Main(string[] args){
            List<Student> students = new List<Student>();
            
            Student student1 = new Student("Sri manikandan", 90, 20);
            Student student2 = new Student("Tejasswin", 80, 20);
            Student student3 = new Student("Garuda Krishna", 70, 20);
            Student student4 = new Student("Sai Sidharthan", 60, 20);

            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            
            Console.Write("Enter the grade threshold: ");
            int threshold = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("\nSort by: 1. Name   2. Grade");
            Console.Write("Choose: ");
            int sortChoice = Convert.ToInt32(Console.ReadLine().Trim());

            var filtered = students.Where(s => s.Grade >= threshold);

            var sorted = students;
            if(sortChoice == 1){
                sorted = students.OrderBy(s => s.Name).ToList();
            }
            else if(sortChoice == 2){
                sorted = students.OrderBy(s => s.Grade).ToList();
            }
            
            Console.WriteLine("\nFiltered students:");
            foreach(var s in filtered){
                Console.WriteLine($"{s.Name}: {s.Grade}");
            }

            Console.WriteLine("\nSorted students:");
            foreach(var s in sorted){
                Console.WriteLine($"{s.Name}: {s.Grade}");
            }
            
        }
    }
}