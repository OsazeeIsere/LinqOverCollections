using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LinqOverCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun with LinqOverCollections");
            // make a list of cars
            List<Car> myCar = new List<Car>() {
            new Car { PetName = "Pencil Light", Color = "Blue", Speed = 50, Make = "Toyota" },
            new Car { PetName = "Tiger Head", Color = "Black", Speed = 40, Make = "Audi" },
            new Car { PetName = "Spirit", Color = "Red", Speed = 100, Make = "Honda" },
            new Car { PetName = "Big for nothing", Color = "Green", Speed = 80, Make = "Toyota" },

            };

            //applying linq on generic
            GetFastCars(myCar);
            LINQOverArrayList();

            Console.ReadLine();
                
    }

        private static void LINQOverArrayList()
        {
            //make a non generic list of cars
            ArrayList myCars = new ArrayList()
            {
                new Car { PetName = "Pencil Light", Color = "Blue", Speed = 50, Make = "Toyota" },
                new Car { PetName = "Tiger Head", Color = "Black", Speed = 40, Make = "Audi" },
                new Car { PetName = "Spirit", Color = "Red", Speed = 100, Make = "Honda" },
                new Car { PetName = "Big for nothing", Color = "Green", Speed = 80, Make = "Toyota" },

            };

            //transform arraylist to IEnumerable<T>- compactible type
            var myCarEnum = myCars.OfType<Car>();

            Console.WriteLine("complex query: capturing speed and make");
            //creat a query axpression targeting the compactible type
            var fastCars = from c in myCarEnum where c.Speed > 50 && c.Make == "Toyota" select c;
            foreach (var item in fastCars)
                Console.WriteLine("{0} make: {1} is going to fast",item.Make, item.PetName);

        }

        private static void GetFastCars(List<Car> myCars)

        {
            //find all cars in the generic list<> where speed the
            //speed is greater than 50
            var fastCars = from c in myCars where c.Speed > 50 select c;
            foreach(var item in fastCars)
                Console.WriteLine("{0} is going to fast",item.PetName);
        }
    }
}
