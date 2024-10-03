using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    internal class Program
    {
        static Random randomGenerator = new Random();
        static List<double> listOfDoubles = new List<double>();

        static void Main(string[] args)
        {
            TenDoubles();

            MenuSystem mainmenu = new MenuSystem("Program");
            
            mainmenu.AddMenuItem("Randomise List of Doubles (10 values)" , "TenDoubles", typeof(Program));
            mainmenu.AddMenuItem("Print List of Doubles", "PrintListOfDoubles", typeof(Program));
            mainmenu.AddMenuItem("Perform a Bubble Sort", "PerformBubble", typeof(Program));
            mainmenu.AddMenuItem("Perform a Quick Sort", "PerformQuick", typeof(Program));

            mainmenu.RunForever();
            Console.ReadKey();


        }

        public static void PerformBubble()
        {
            Console.WriteLine("Performing Bubblesssss");
            BubbleSort.Perform(listOfDoubles);
            Console.WriteLine("Sort Done!");
        }

        public static void PerformQuick()
        {
            Console.WriteLine("Performing QUICKIEEEEE");
            listOfDoubles = QuickSort.Perform(listOfDoubles, 0, listOfDoubles.Count - 1);
            Console.WriteLine("Sort Done");
        }
        public static void TenDoubles()
        {
            Console.WriteLine(" Random number list for doubles coming right up!...... ");
            PopulateListWithRandomDoubles(10);
            Console.WriteLine("List done!");
        }

        static void PopulateListWithRandomDoubles(int size)
        {
            listOfDoubles.Clear();

            for (int i = 0; i < size; i++) 
            {
                double twoDigitDouble = Double.Parse(randomGenerator.NextDouble().ToString("0.0000"));
                listOfDoubles.Add(twoDigitDouble);
                
            }
        }

        public static void PrintListOfDoubles()
        {
            Console.WriteLine("\n\nList Print:\n");

            for (int i = 0;i < listOfDoubles.Count;i++)
            {
                Console.WriteLine(" " + listOfDoubles[i].ToString());
            }
            Console.WriteLine("\nEnd \n");
        }
    }
}
