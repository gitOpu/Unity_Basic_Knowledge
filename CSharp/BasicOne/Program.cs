using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
 

namespace BasicOne
{
    public class AnimalTypeAttribute : Attribute
    {
        // The constructor is called when the attribute is set.
        public AnimalTypeAttribute(Animal pet)
        {
            thePet = pet;
        }

        // Keep a variable internally ...
        protected Animal thePet;

        // .. and show a copy to the outside world.
        public Animal Pet
        {
            get { return thePet; }
            set { thePet = value; }
        }
    }
    public class AnimalTypeTestClass
    {
        [AnimalType(Animal.Dog)]
        public void DogMethod() { }

        [AnimalType(Animal.Cat)]
        public void CatMethod() { }

        [AnimalType(Animal.Bird)]
        public void BirdMethod() { }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Console.ReadKey();
        }
        static void AttributeExample()
        {
            AnimalTypeTestClass testClass = new AnimalTypeTestClass();
            Type type = testClass.GetType();
            // Iterate through all the methods of the class.
            foreach (MethodInfo mInfo in type.GetMethods())
            {
                // Iterate through all the Attributes for each method.
                foreach (Attribute attr in
                    Attribute.GetCustomAttributes(mInfo))
                {
                    // Check for the AnimalType attribute.
                    if (attr.GetType() == typeof(AnimalTypeAttribute))
                        Console.WriteLine(
                            "Method {0} has a pet {1} attribute.",
                            mInfo.Name, ((AnimalTypeAttribute)attr).Pet);
                }
            }
        }
        static void CompareableTest()
        {
            MyClass obj1 = new MyClass { Value = 5 };
            MyClass obj2 = new MyClass { Value = 3 };

            int comparisonResult = obj1.CompareTo(obj2);

            if (comparisonResult < 0)
                Console.WriteLine("obj1 is less than obj2");
            else if (comparisonResult > 0)
                Console.WriteLine("obj1 is greater than obj2");
            else
                Console.WriteLine("obj1 is equal to obj2");
        }
        static void WorkingWithQueue()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            queue = new Queue<string>(Remove(queue, "B", true));


            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
        static Queue<string> Remove(Queue<string> oldQueue, string requesetedItem, bool andAgainInsetAtEnd = false)
        {
            Queue<string> updateQueue = new Queue<string>();
            
           if(oldQueue.Count > 0 && oldQueue.Contains(requesetedItem))
            {
                while (oldQueue.Count > 0)
                {
                    string item = oldQueue.Dequeue();
                    if (item != requesetedItem) updateQueue.Enqueue(item);
                }

                if(andAgainInsetAtEnd)
                updateQueue.Enqueue(requesetedItem);

                return updateQueue;
            }
            else
            {
                if (andAgainInsetAtEnd)
                    oldQueue.Enqueue(requesetedItem);
               return oldQueue;
            }
           
        }
        private static void TestcDic()
        {
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            dic.Add("a", true);
            dic.Add("b", true);
            dic.Add("c", true);

            dic.Remove("b");


            Console.WriteLine(dic.Count);
            dic.Add("d", true);
            foreach (var item in dic)
            {
                Console.WriteLine(item.Key);
            }
        }
        // 4 Class with Constructor
        static void ExContructor()
        {
            Book book1 = new Book("Harry Potter");
            Console.WriteLine(book1.title);
        }
         // 3 Example of Try Catch
        static void TryCatch()
        {
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }
            finally
            {

            }
        }
        // 2: print a grid ot row 5, column = 7
        static void Grid(int row, int column)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write($"({i},{j}); ");
                     
                }
                Console.Write("\n");
            }
        }
        //1: Write a program that print a sequential tuple series with negative values?
        static void SequentialSeriesWithNegativeNumber()
        {
            for (int i = 1; i < 24; i++)
            {
                int value = (int)i / 2;
                Console.Write(Math.Pow(-1, i) * value + ", ");
            }
        }
    }
    
}
