using System;
using System.Collections.Generic;

namespace task8{
    interface IEntity{
        int Id { get; set; }
    }
    interface IRepository<T> where T : class, IEntity{
        void Add(T entity);
        T Get(int id);
        void Delete(int id);

        List<T> GetAll();
    }


    class Repository<T> : IRepository<T> where T : class, IEntity{
        private List<T> _storage = new List<T>();

        public void Add(T entity){

            _storage.Add(entity);

            Console.WriteLine($"Added: ID {entity.Id}");
        }
        public T Get(int id){
            foreach (var item in _storage)
                if (item.Id == id) return item;

            return null;
        }

        public void Delete(int id){
            T item = Get(id);

            if (item == null){
                Console.WriteLine($"ID {id} not found.");
                return;
            }
            _storage.Remove(item);

            Console.WriteLine($"Deleted: ID {id}");
        }
        public List<T> GetAll(){
            return _storage;
        }
    }

    class Student : IEntity
    {
        public int    Id   { get; set; }

        public string Name { get; set; }

        public Student(int id, string name)
        {
            Id   = id;
            Name = name;
        }


        public override string ToString()
        {
            return $"ID: {Id}  Name: {Name}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Repository<Student> repo = new Repository<Student>();

            repo.Add(new Student(1, "Manish"));
            repo.Add(new Student(2, "Garuda"));
            repo.Add(new Student(3, "Sai"));

            Console.WriteLine("\nAll Students");

            foreach (var s in repo.GetAll())
                Console.WriteLine(s);

            Console.WriteLine("\nGet ID 2");
            Student found = repo.Get(2);
            Console.WriteLine(found != null ? found.ToString() : "Not found");
            
            Console.WriteLine("\nDelete ID 1");
            repo.Delete(1);


            Console.WriteLine("\nAll Students After Delete");
            foreach (var s in repo.GetAll())
                Console.WriteLine(s);
        }
    }
}
