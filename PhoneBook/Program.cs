using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PhoneBook
{

    public class Menu
    {

        public void DisplayMenuOptions()
        {
            string[] menuOptions =
            {
            "1. Get all phone numbers",
            "2. Add a new phone number",
            "3. Edit a phone number",
            "4. Delete a phone number"
             };

            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine(menuOptions[i]);
            }
        }

        public void GetAllPhoneNumbers()
        {
            List<Contact> contacts = PhoneBookOperations.GetContactsFromJSON("phonebook.json");

            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone Number: {contact.PhoneNumber}");
            }
        }


        public void MenuDisplay()
        {
            bool exitProgram = false;
            int userNumber = 0;

            while (exitProgram == false)
            {
                Console.WriteLine("Welcome to this menu program");
                Console.WriteLine("To exit the program at any time, write quit or exit");

                DisplayMenuOptions();

                string input = Console.ReadLine().ToLower();
                if (input == "quit" || input == "exit")
                {
                    Console.WriteLine("Exiting program.....");
                    exitProgram = true;
                } 

                try
                {
                    userNumber = Convert.ToInt32(input);
                }
                catch (FormatException)
                {

                    Console.WriteLine("Invalid input, please enter a number.");
                }
                
               

                switch (userNumber)
                {
                    case 1:
                        Console.WriteLine("Display all phone numbers: ");
                        GetAllPhoneNumbers();
                        break;
                    case 2:
                        //phonebookOperations.AddPhoneNumber();
                        break;
                    case 3:
                        //phonebookOperations.EditPhoneNumber(int id);
                        break;
                    case 4:
                        //phonebookOperations.DeletePhoneNumber(int id);
                        break;

                }
            }
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }


    public class PhoneBookOperations
    {
        //metod för att hämta alla telefonnummer
        public static List<Contact> GetContactsFromJSON (string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);

                List<Contact> contacts = JsonSerializer.Deserialize<List<Contact>>(jsonString);

                return contacts;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
                return new List<Contact>();
            }
        }

        //metod för att lägga till nytt telefonnummer

        //metod för att redigera telefonnummer

        //metod för att ta bort telefonnummer
    }
    public class PhoneBook
    {
        static void Main(string[] args)
        {
            Menu menuTest = new Menu();
            menuTest.MenuDisplay();
        }
    }
}
