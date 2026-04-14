using System;

namespace task2{
    class Person{
        public string Name;
        public int Age;

        public Person(string name, int age){
            Name = name;
            Age = age;
        }

        public void Introduce(){
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }
    }
    class Program{

        static void Main(string[] args){
            Person person1 = new Person("Manish", 30);
            Person person2 = new Person("Sai", 25);
            Person person3 = new Person("Garuda", 35);

            person1.Introduce();
            person2.Introduce();
            person3.Introduce();
        }

    }
}
