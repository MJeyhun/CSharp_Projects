using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp
{
    public class DisplayShow
    {
        public static void ShowDisplay(string filePath) 
        {
            
           
            Console.WriteLine("Options:\n1.Add new contact:\n2.Remove contact:\n3.Find contact:\n4.Show all contacts:\n5.Edit contact:\n6.Exit\n7.Clear Console");
           
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out int option))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter proper option:");
                Console.ForegroundColor= ConsoleColor.White;
                ShowDisplay(filePath);
            }
            Console.Clear();
            GoOption(option, filePath);
            
        }
        public static void GoOption(int option,string filePath)
        {

            switch (option)
            {
                
                case 1:
                    ContactCRUD.ContactCreate(filePath);
                    break;
                case 2:
                    ContactCRUD.ContactRemove(filePath);
                    break;
                case 3:
                    ContactCRUD.ShowContact(filePath);
                    break;
                case 4:
                    ContactCRUD.ShowAllContacts(filePath);
                    break;
                case 5: 
                    ContactCRUD.ContactEdit(filePath);
                    break;
                case 6:
                    Console.WriteLine("Good Bye!");
                    return;
                case 7:
                    Console.Clear();
                    DisplayShow.ShowDisplay(filePath);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter proper option!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

            }
            ShowDisplay(filePath);
        }
    }
}
