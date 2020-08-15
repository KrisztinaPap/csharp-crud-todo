using System;
// Citation
//      https://www.youtube.com/watch?reload=9&v=RQ0JHMGiobo&feature=youtu.be
//      Need this Collection to be able to manipulate lists
using System.Collections.Generic;

namespace c_assignment_crud_KrisztinaPap
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                Title: C# Assignment - CRUD ("The Best To-Do List")
                Problem/Purpose: Practicing decisions, iteration, and data structures in C#. This application allows the user to create and manipulate a list with 10 string items.
                Author: Krisztina Pap
                Date of last edit: August 14, 2020
            */

            // Declare variables
            int userAction = -1; // The number of the menu item (action) the user chooses
            int howToDelete = 0; // For the delete sub-menu
            int howToUpdate = 0; // For the update sub-menu

            // Citation:
            //      https://www.youtube.com/watch?reload=9&v=RQ0JHMGiobo&feature=youtu.be
            //      The below line of code initializes an empty list
            List<string> userList = new List<string> ();


            // Explains to user what the program does and how to use it
            Console.WriteLine("Welcome to 'The Best To-Do List'! This program allows you to create and maintain a list of ten things you don't want to forget to do.");

            // Loop to continue showing user the main menu until they choose option 5 to quit
            while ( userAction != 5 )
            {
                // Shows user program menu and wait for input
                // show shorter menu (no edit and delete options if list is empty)
                if (userList.Count == 0)
                {
                    ShowMenuEmptyList();
                }
                else if (userList.Count == 10)
                {
                    ShowMenuFull();
                }
                else{
                    ShowMenu();
                }
                
                userAction = int.Parse(Console.ReadLine());
                

                // If user chooses 1. Add a new item
                if ( userAction == 1 )
                {
                    // User can only add a new item if the list is not full
                    if ( userList.Count != 10 )
                    {
                        AddValidString("Enter the item you want to add or \"menu\" to return to the menu:", userList);
                    }
                }

                // If user chooses 2. Delete an item
                else if ( userAction == 2 )
                {
                    // Asks user whether they want to delete by index number or name

                    Console.WriteLine("Do you want to delete by:\n  1. index \n  2. name\n(enter the corresponding number)");
                    howToDelete =  Convert.ToInt32(Console.ReadLine());

                        // If user chooses to delete by index number

                        if ( howToDelete == 1 )
                        {
                            DeleteByIndex(userList); 
                        }

                        // If user chooses to delete by name

                        else if ( howToDelete == 2 )
                        {
                            DeleteByName(userList);
                        }

                        // If the user chooses anything but option 1 or 2

                        else 
                        {
                            Console.WriteLine("That's not a valid choice!");
                        }

                    }

                // If user chooses 3. Edit an item
                else if ( userAction == 3 )
                {
                    // Asks user whether they want to update by index number or name

                    Console.WriteLine("Do you want to update by:\n  1. index \n  2. name\n(enter the corresponding number)");
                    howToUpdate =  Convert.ToInt32(Console.ReadLine());

                        // If user chooses to update by index number

                        if ( howToUpdate == 1 )
                        {
                            UpdateByIndex(userList); 
                        }

                        // If user chooses to update by name

                        else if ( howToUpdate == 2 )
                        {
                            UpdateByName(userList);
                        }

                        // If the user chooses anything but option 1 or 2

                        else 
                        {
                            Console.WriteLine("That's not a valid choice!");
                        }
                }

                // If user chooses 4. See the list
                else if ( userAction == 4 )
                {
                    DisplayList(userList);
                }

                else if ( userAction == 5 )
                {
                    Console.WriteLine("Thank you for using 'The Best To-Do List'! Press enter to quit...");
                }

                // If user chooses anything but the menu options available (1-5)
                else
                {
                    Console.WriteLine("'{0}' is not a valid menu option. Please try again!", userAction); 
                }
            }
        }

        // Citation:
        // James Grieve C# lesson notes - validation methods
        // The below code block creates a method that takes in a prompt and a list
        // Starts by setting valid to false and newString to an empty string
        // Displays the prompt (input instructions to the user)
        // Saves user input in newString and tests it against conditions (duplicate? empty string? shorter than 2 characters?) - if so, throws and error and prompts again for input
        // If valid, method returns newString
        static void AddValidString(string thePrompt, List<string> theList)
        {
            bool valid = false;
            string userInput = "";
            do
            {
                Console.WriteLine(thePrompt);
                userInput = Console.ReadLine();
                try
                {
        
                    userInput = CleanUpInput(userInput);
                    
                        
                    if ( userInput == "" || theList.Contains(userInput) || userInput.Length < 2 )
                    {
                        throw new Exception();
                    }
            
                    valid = true;
                    if (userInput != "menu")
                    {
                        theList.Add(userInput);
                        Console.WriteLine("The item '{0}' was added to your list.", userInput); 
                    }
 
                }
                catch (Exception ex)
                {
                    // Citation:
                    //      https://github.com/TECHCareers-by-Manpower/OddEvenSorter/blob/0e9c9e590a22d1059ed1bd75c440007d485606ac/Program.cs
                    //      When the user enters 'menu', he doesn't get an error message, it just goes back to the main menu
                    if ( userInput != "menu" ) // Big shout-out to Aaron Barthel for his excellent suggestions!
    
                    {
                        Console.WriteLine($"Invalid input: {ex.Message}");
                    }
                }
            } while ( !valid || theList.Count < 10 && userInput != "menu" );

        }

        // A method to clean up user string input - trims whitespaces and converts to all lowercase
        static string CleanUpInput(string theInput)
        {
            string cleanInput = theInput.Trim().ToLower();
            return cleanInput;
        }

        // Citation:
        //      https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=netcore-3.1
        //      The below code block is a method that takes in a list and loops over its elements, printing each one out in turn
        static void DisplayList(List<string> theList)
        {
            // Sorts the list alphabetically before displaying it
            theList.Sort();
            Console.WriteLine("TO-DO LIST\n-------------");
            for (int i = 0; i <= theList.Count - 1; i++)
                {
                    
                    // using (i+1) so user doesn't see items zero-indexed 
                    Console.WriteLine( (i+1) + ". " + theList[i] );
                }
            Console.WriteLine("-------------");
        }

        public static void ShowMenu()
        {       
            Console.WriteLine("---------------------\n      MAIN MENU\n---------------------\n| 1. Add a new item |\n| 2. Delete an item |\n| 3. Edit an item   |\n| 4. See the list   |\n| 5. Quit program   |\n---------------------");
     
        }

        public static void ShowMenuEmptyList()
        {       
            Console.WriteLine("---------------------\n      MAIN MENU\n---------------------\n| 1. Add a new item |\n| 5. Quit program   |\n---------------------");
     
        }

        public static void ShowMenuFull()
        {       
            Console.WriteLine("---------------------\n      MAIN MENU\n---------------------\n| 2. Delete an item |\n| 3. Edit an item   |\n| 4. See the list   |\n| 5. Quit program   |\n---------------------");
     
        }

        public static void DeleteByIndex(List<string> theList)
        {
            
            int indexToDelete;

            Console.WriteLine("What is the index number of the name you want to delete?");
            indexToDelete = Convert.ToInt32(Console.ReadLine());

            theList.RemoveAt (indexToDelete - 1);
            Console.WriteLine("Done!");
        }

        public static void DeleteByName(List<string> theList)
        {  
            string nameToDelete = "";

            Console.WriteLine("What name do you want to delete?");
            nameToDelete = CleanUpInput(Console.ReadLine());

            theList.Remove (nameToDelete);
            Console.WriteLine("Done!");
        }

        public static void UpdateByIndex(List<string> theList)
        {
            int indexToUpdate;
            string userInput = "";         

            
                Console.WriteLine("What is the index number you want to update?");
                bool IsItInt = Int32.TryParse(Console.ReadLine(), out indexToUpdate);

                if (IsItInt)
                {
                    indexToUpdate = Convert.ToInt32(indexToUpdate)-1;
                }
                else
                {
                    Console.WriteLine("That's not an integer!");
                }
               
                Console.WriteLine("What is the new item?");
                userInput = Console.ReadLine();
                       
                userInput = CleanUpInput(userInput).ToString();
                                         
                // Citation:
                //      https://stackoverflow.com/questions/17188966/how-to-replace-list-item-in-best-way
                //      The below code line replaces a specific index in the list with a new input variable 
                
                theList.RemoveAt(indexToUpdate);
                theList.Insert(indexToUpdate, userInput.ToString());
                Console.WriteLine("Done!");
        }
        
        public static void UpdateByName(List<string> theList)
        {
            int indexToUpdate;
            string userInput = "";
            string nameToUpdate = "";

            Console.WriteLine("What item name do you want to update?");
            nameToUpdate = CleanUpInput(Console.ReadLine());
            indexToUpdate = theList.IndexOf(nameToUpdate);

            Console.WriteLine("What is the new item?");
            userInput = Console.ReadLine();
                    
            userInput = CleanUpInput(userInput).ToString();
                                        
            // Citation:
            //      https://stackoverflow.com/questions/17188966/how-to-replace-list-item-in-best-way
            //      The below code line replaces a specific index in the list with a new input variable 
            
            theList.RemoveAt(indexToUpdate);
            theList.Insert(indexToUpdate, userInput.ToString());
            Console.WriteLine("Done!");

        }
    }
}