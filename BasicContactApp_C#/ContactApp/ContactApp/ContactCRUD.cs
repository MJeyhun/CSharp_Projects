using ContactApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Transactions;

namespace ContactApp
{
    public class ContactCRUD
    {
        public static void ContactCreate(string filePath)
        {

            Console.Clear();
            Contact newContact = new Contact();
        FullName:
            Console.Write("Full name:");
            string fullName = Console.ReadLine();
            Contact[] Contacts = DBFunctions.GetAllContacts(filePath);
        Number:
            Console.Write("Number:");
            string number = Console.ReadLine();
            foreach (Contact c in Contacts)
            {
                if (fullName == c.FullName && c.isDeleted == false)
                {
                    Console.WriteLine("This name exists in phone book, please choose other one:");
                    goto FullName;
                }
                else if (number == c.Number && c.isDeleted == false)
                {
                    Console.WriteLine("This number exists in phone book, please choose other one:");
                    goto Number;
                }
            }
        Decision:
            Console.Write($"Do you want to add phone book this contact  Fullname:{fullName}  Number:{number}\n Please enter y or n:");
            string decision = Console.ReadLine();
            if (decision == "y" || decision == "Y")
            {
                newContact.FullName = fullName;
                newContact.Number = number;
                newContact.Id = Contacts.Length + 1;
                newContact.isDeleted = false;

                DBFunctions.AddContact(newContact, filePath);
                return;
            }
            else if (decision == "n" || decision == "N") return;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter proper option!");
                Console.ForegroundColor = ConsoleColor.White;
                goto Decision;
            }
        }
        public static void ContactEdit(string filePath) 
        {
            Console.WriteLine("What do you want edit? name or number");
            string decision= Console.ReadLine();
            Console.WriteLine("Which contact you want to edit?Enter full name!");
            string name= Console.ReadLine();
            DBFunctions.EditContact(decision,name,filePath);
            return;
        }
        public static void ShowContact(string filePath) 
        {
            Console.Write("Enter full name:");
            string name= Console.ReadLine();
            Contact[] Contacts=DBFunctions.GetContact(name, filePath);
            for (int i = 0; i < Contacts.Length; i++)
            {
                if (!Contacts[i].isDeleted)
                {
                    Console.WriteLine($"{i + 1}.Full name:{Contacts[i].FullName} Number:{Contacts[i].Number}\n");
                }
            }
        ContactsDecision:
            Console.WriteLine("Go to main menu:y");
            string decision = Console.ReadLine();
            if (decision == "y" || decision == "Y") DisplayShow.ShowDisplay(filePath);
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter proper option!");
                Console.ForegroundColor = ConsoleColor.White;
                goto ContactsDecision;
            }
        }
        public static void ContactRemove(string filePath) 
        {
            Console.Clear();
            Console.Write("Name of contact:");
            string fullname = Console.ReadLine();
        Decision:
            Console.Write($"Do you want to remove {fullname}? y or n");
            string decision= Console.ReadLine();
            if (decision == "y" || decision == "Y") DBFunctions.RemoveContact(fullname, filePath);
            else if (decision == "n" || decision == "N") return;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter proper option!");
                Console.ForegroundColor = ConsoleColor.White;
                goto Decision;
            }


        }
        public static void ShowAllContacts(string filePath) 
        {
            Contact[] Contacts = DBFunctions.GetAllContacts(filePath);

            for (int i = 0; i < Contacts.Length; i++) 
            {
                if (!Contacts[i].isDeleted) 
                {
                    Console.WriteLine($"{i+1}.Full name:{Contacts[i].FullName} Number:{Contacts[i].Number}\n");
                }
            }
        ContactsDecision:
            Console.WriteLine("Go to main menu:y");
            string decision = Console.ReadLine();
            if (decision == "y" || decision == "Y") DisplayShow.ShowDisplay(filePath);
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter proper option!");
                Console.ForegroundColor = ConsoleColor.White;
                goto ContactsDecision;
            }
        }
    }
}
