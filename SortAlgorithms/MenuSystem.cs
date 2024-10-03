using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    internal class MenuSystem
    {
        string callingClass;
        Dictionary<string, MethodInfo> menuOptions;

        public MenuSystem(string callingClassName)
        {
            callingClass = callingClassName;
            menuOptions = new Dictionary<string, MethodInfo>(); //dictionary name = menuOptions (also holds key), Values name= MethodInfo

            Type thisType = typeof(Environment); // i dont understand.....ask chatGPT????
            AddMenuItem("Exit Application", thisType.GetMethod("Exit"));
            this.callingClass = callingClass;
        }

        public void RunForever()
        {
            while (true)
            {
                Run();
            }
        }

        public void Run()
        {
            DisplayOptions();
            GetMenuSelections();

        }

        public void DisplayOptions() 
        {
            Console.Clear();
            Console.WriteLine("Please choose from the Following options: \n");
            int i = 0; // i HAS to be claimed, but will be replace from 0 to keys

            foreach (string menuItem in menuOptions.Keys) // loops through dictonary and outputs keys
            {

                Console.WriteLine("(" + i + ") " + menuItem); // ($"({i}) {menuItem}"); Robin says do this cause its prettier (formatted string)
                i++;
            }
             
            Console.WriteLine("\n\n");

        }

        public void GetMenuSelections()
        {
            string userInput = Console.ReadLine();

            MethodInfo mi;

            // has the user entered a int value?
            if (int.TryParse(userInput, out int integerInput))
            {
                if (integerInput == 0)
                {
                    mi = menuOptions.ElementAt(integerInput).Value;
                    mi.Invoke(this, new object[] { 0 });
                    Console.ReadKey();
                }
                else if (integerInput > 0 && integerInput < menuOptions.Count) 
                {
                    mi = menuOptions.ElementAt(integerInput).Value;
                    mi.Invoke(this, null);
                    Console.ReadKey();
                
                }
            }
        }

        public void AddMenuItem(string menuMessage, MethodInfo methodinfo)
        {
            menuOptions.Add(menuMessage, methodinfo);
        }

        public void AddMenuItem(string menuMessage, string methodName, Type callingType) 
        {
            MethodInfo methodinfo = callingType.GetMethod(methodName);
            menuOptions.Add(menuMessage, methodinfo);
        }

    }
}

