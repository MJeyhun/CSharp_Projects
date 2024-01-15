using ContactApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;



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
        public static void RemoveContact(string name,string filePath) 
        {
            List<Contact> Contacts = new List<Contact>();

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        Contact obj = JsonConvert.DeserializeObject<Contact>(line);
                        Contacts.Add(obj);
                    }
                }
            }
            foreach (Contact Contact in Contacts) 
            {
                if (Contact.FullName == name)
                {
                    //Contacts.Remove(Contact); 
                    Contact.isDeleted = true;
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (Contact obj in Contacts)
                        {
                            
                            string serializedObj = JsonConvert.SerializeObject(obj);

                           
                            writer.WriteLine(serializedObj);
                        }

                        
                        writer.Flush();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Contact is succesfuly deleted!");
                    Console.ForegroundColor = ConsoleColor.White;
                    DisplayShow.ShowDisplay(filePath);
                }
                
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("This contact does not exist in phone book!");
            Console.ForegroundColor = ConsoleColor.White;
            DisplayShow.ShowDisplay(filePath);
        }
        public static void EditContact(string decision,string name,string filePath) 
        {
            if (decision.ToLower() == "name")
            {
                Console.Write("Enter new name:");
                string newName = Console.ReadLine();
                List<Contact> Contacts = new List<Contact>();

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            Contact obj = JsonConvert.DeserializeObject<Contact>(line);
                            Contacts.Add(obj);
                        }
                    }
                }
                foreach (Contact cont in Contacts) 
                {
                    if (cont.FullName == name) {
                        cont.FullName = newName;
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            foreach (Contact obj in Contacts)
                            {

                                string serializedObj = JsonConvert.SerializeObject(obj);


                                writer.WriteLine(serializedObj);
                            }


                            writer.Flush();
                        }
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine("Contact name updated!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                }
            }
            else if (decision.ToLower() == "number")
            {
                Console.Write("Enter new number:");
                string newNumb = Console.ReadLine();
                List<Contact> Contacts = new List<Contact>();

                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            Contact obj = JsonConvert.DeserializeObject<Contact>(line);
                            Contacts.Add(obj);
                        }
                    }
                }
                foreach (Contact cont in Contacts)
                {
                    if (cont.FullName == name)
                    {
                        cont.Number = newNumb;
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            foreach (Contact obj in Contacts)
                            {

                                string serializedObj = JsonConvert.SerializeObject(obj);


                                writer.WriteLine(serializedObj);
                            }


                            writer.Flush();
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Contact number updated!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }
                }

            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter proper option!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            DisplayShow.ShowDisplay(filePath);

        }
        public static Contact[] GetContact(string name,string filePath) 
        {
            Contact[] Contacts = GetAllContacts(filePath);
            List<Contact> contactsReturn = new List<Contact>();

            foreach (Contact Contact in Contacts) 
            {
                if(Contact.FullName.Contains(name)) contactsReturn.Add(Contact);
            }
            if (contactsReturn.Count() == 0) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This contact does not exists!");
                Console.ForegroundColor = ConsoleColor.White;
                DisplayShow.ShowDisplay(filePath);
            }
            return contactsReturn.ToArray();
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
