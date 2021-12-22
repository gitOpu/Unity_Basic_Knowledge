using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicOne
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(100 % 25 == 0);

            Console.ReadLine();
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
