using ContactApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace ContactApp
{
    public class DBFunctions
    {
        public static  void AddContact(Contact NewContact,string filePath) 
        {
            string serializedContact = JsonConvert.SerializeObject(NewContact);
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(serializedContact);
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Contact added to the phone book!");
            Console.ForegroundColor = ConsoleColor.White;
            DisplayShow.ShowDisplay(filePath);
        }
        static void RemoveContact() 
        {

        }
        static void EditContact() 
        {

        }
        static void GetContact() 
        {

        }
        public static Contact[] GetAllContacts(string filePath)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }
  
            List<Contact> Contacts = new List<Contact>();
            foreach (string line in lines)
            {
                Contact contact = JsonConvert.DeserializeObject<Contact>(line);
                Contacts.Add(contact);
            }
            return Contacts.ToArray();
        }
    }
}
