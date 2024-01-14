using ContactApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


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
                if (fullName == c.FullName)
                {
                    Console.WriteLine("This name exists in phone book, please choose other one:");
                    goto FullName;
                }
                else if (number == c.Number)
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

                DBFunctions.AddContact(newContact,filePath);
                return;
            }
            else if (decision == "n" || decision == "N")
            {
                return;
            }
            else 
            {
                Console.ForegroundColor= ConsoleColor.Red;
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
            Console.WriteLine("Go to main menu:y or n");
            string decision = Console.ReadLine();
            if (decision == "y" || decision == "Y") DisplayShow.ShowDisplay(filePath);
            else if (decision == "n" || decision == "N") return;
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
