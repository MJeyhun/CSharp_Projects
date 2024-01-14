using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactFunctionsLibrary
{
    public class MainMenu
    {
        static void ShowDisplay(int option)
        {
      
            switch (option) 
            {
               
                case 1: //Add contact
                    break;
                case 2://Remove contact
                    break;
                case 3://Find contact
                    break;
                case 4: //Show all contacts
                    break;
                case 5: //Exit
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter proper option!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }
        }

    }
}
