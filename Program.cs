using System;
// Citation
//      https://www.youtube.com/watch?reload=9&v=RQ0JHMGiobo&feature=youtu.be
//      Need this Collection to be able to manipulate lists
using System.Collections.Generic;
// Citation
//      https://www.dotnetperls.com/streamwriter
//      Below line of code allows us to save a text file
using System.IO;

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
                Date of last edit: August 15, 2020
            */

            // Declare variables
            int userAction = -1; // The number of the menu item (action) the user chooses
            int howToDelete = 0; // For the delete sub-menu
            int howToEdit = 0; // For the edit sub-menu

            // Citation:
            //      https://www.youtube.com/watch?reload=9&v=RQ0JHMGiobo&feature=youtu.be
            //      The below line of code initializes an empty list
            List<string> userList = new List<string> ();


            // Explains to user what the program does and how to use it
            Console.WriteLine("Welcome to 'The Best To-Do List'! This program allows you to create and maintain a list of ten things you don't want to forget to do.");

            // Loop to continue showing user the main menu until they choose option 5 to quit
            while ( userAction != 7 )
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
                else {
                    ShowMenu();
                }
                
                GetValidInt("Enter your choice:", ref userAction);                

                // If user chooses 1. Add a new item
                if ( userAction == 1 )
                {
                    // User can only add a new item if the list is not full
                    if ( userList.Count != 10 )
                    {
                        GetValidListItem("Enter the item you want to add or \"menu\" to return to the menu:", userList);
                    }
                }

                // If user chooses 2. Delete an item
                else if ( userAction == 2 )
                {
                    DecideByIndexOrName("delete", ref howToDelete);

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
                    DecideByIndexOrName("edit", ref howToEdit);

                        // If user chooses to edit by index number
                        if ( howToEdit == 1 )
                        {
                            EditByIndex(userList); 
                        }

                        // If user chooses to edit by name
                        else if ( howToEdit == 2 )
                        {
                            EditByName(userList);
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

                // If user chooses 5. Save list as a txt file
                else if ( userAction == 5 )
                {
                    SaveFile(userList);
                }

                // If user chooses 6. Imports list from a txt file
                else if ( userAction == 6 )
                {
                    ImportFile(userList);
                }

                else if ( userAction == 7 )
                {
                    Console.WriteLine("Thank you for using 'The Best To-Do List'!");
                }

                // If user chooses anything but the menu options available (1-6)
                else
                {
                    Console.WriteLine("'{0}' is not a valid menu option. Please try again!", userAction); 
                }
            }
        }

        // Citation:
        //      https://codeasy.net/lesson/input_validation
        //      The below block of code takes in user input and tries parsing it as an integer. If it fails, the user gets prompted again. If it succeeds, it passes the valid number out. 
        public static void GetValidInt(string thePrompt, ref int intVariable)
        {
            Console.WriteLine(thePrompt);
            var userInput = Console.ReadLine();

            while (!Int32.TryParse(userInput, out intVariable))
            {
                Console.WriteLine("That's not an integer!");
                userInput = Console.ReadLine();
            } 
        }

        // Citation:
        //      James Grieve C# lesson notes - validation methods
        //      https://github.com/TECHCareers-by-Manpower/OddEvenSorter/blob/0e9c9e590a22d1059ed1bd75c440007d485606ac/Program.cs
        //      The below code block checks if the user's input meets the criteria we set for our list items. (details above each section below!)

        // The method takes in a user prompt, the string variable we will be saving our result in, and the name of the list we need to check duplicates against
        public static void GetValidListItem(string thePrompt, List<string> theList)
        {
            // Sets a bool value so we can keep looping until the user enters a valid input
            bool valid = false;
            string userInput = "";
            do
            {
                // We prompt the user for their input
                Console.WriteLine(thePrompt);
                userInput = Console.ReadLine();
                try
                {
                    // First we clean up the input: trim leading and trailing whitespace, and convert to all lowercase
                    userInput = CleanUpInput(userInput);

                    // We check if it's an empty string or a duplicate. If so, we throw an error and ask again
                    if ( userInput == "" || theList.Contains(userInput) )
                    {
                        throw new Exception();
                    }
                    // If the try succeeds, we can set valid to true, the user's input can be added to the list
                    valid = true;

                    // If the user enters the sentiinel value ("menu"), the program will break out of this loop and return them to the main menu
                    if (userInput != "menu")
                    {
                        // Once we know it's a valid input, we can run the AddItem method to add our new item to the list
                        AddItem(theList, userInput);
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
            
            // The loop runs until the user enters a valid string, the list is full, or the user types in the word "menu" (sentinel value)
            } while ( !valid || theList.Count < 10 && userInput != "menu" );
        }

        public static void GetValidItem(string thePrompt, List<string> theList, ref string userInput)
        {
            // Sets a bool value so we can keep looping until the user enters a valid input
            bool valid = false;
            userInput = "";
            do
            {
                // We prompt the user for their input
                Console.WriteLine(thePrompt);
                userInput = Console.ReadLine();
                try
                {
                    // First we clean up the input: trim leading and trailing whitespace, and convert to all lowercase
                    userInput = CleanUpInput(userInput);

                    // We check if it's an empty string or a duplicate. If so, we throw an error and ask again
                    if ( userInput == "" || theList.Contains(userInput) )
                    {
                        throw new Exception();
                    }
                    // If the try succeeds, we can set valid to true, the user's input can be added to the list
                    valid = true;
                }
                catch (Exception ex)
                {                    
                    Console.WriteLine($"Invalid input: {ex.Message}");  
                }
            
            // The loop runs until the user enters a valid string
            } while ( !valid );
        }

        public static void AddItem(List<string> theList, string userInput)
        {
            theList.Add(userInput);
            Console.WriteLine("The item '{0}' was added to your list.", userInput); 
        }

        // A method to clean up user string input - trims whitespaces and converts to all lowercase
        public static string CleanUpInput(string theInput)
        {
            string cleanInput = theInput.Trim().ToLower();
            return cleanInput;
        }

        // Citation:
        //      https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=netcore-3.1
        //      The below code block is a method that takes in a list and loops over its elements, printing each one out in turn
        public static void DisplayList(List<string> theList)
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
            Console.WriteLine("---------------------------------\n            MAIN MENU\n---------------------------------\n| 1. Add a new to-do item       |\n| 2. Delete a to-do item        |\n| 3. Edit a to-do item          |\n| 4. Display your list          |\n| 5. Save your list to a file   |\n| 6. Import a list from a file  |\n| 7. Quit program               |\n---------------------------------");
        }

        public static void ShowMenuEmptyList()
        {       
            Console.WriteLine("---------------------------------\n            MAIN MENU\n---------------------------------\n| 1. Add a new to-do item       |\n| 6. Import a list from a file  |\n| 7. Quit program               |\n---------------------------------");
        }

        public static void ShowMenuFull()
        {       
            Console.WriteLine("---------------------------------\n            MAIN MENU\n---------------------------------\n| 2. Delete a to-do item        |\n| 3. Edit a to-do item          |\n| 4. Display your list          |\n| 5. Save your list to a file   |\n| 6. Import a list from a file  |\n| 7. Quit program               |\n---------------------------------");
        }

        public static void DeleteByIndex(List<string> theList)
        {
            int indexToDelete = -1;

            GetValidInt("What is the index number of the name you want to delete?", ref indexToDelete);

            theList.RemoveAt (indexToDelete - 1);
            Console.WriteLine("Done!");
        }

        public static void DeleteByName(List<string> theList)
        {  
            string nameToDelete = "";

            Console.WriteLine("What name do you want to delete?");
            nameToDelete = CleanUpInput(Console.ReadLine());

            if ( theList.Contains(nameToDelete))
            {
                theList.Remove (nameToDelete);
                Console.WriteLine("Done!");
            }
            else
            {
                Console.WriteLine("That item is not on your list!");
            }
        }

        public static void EditByIndex(List<string> theList)
        {
            int indexToEdit = -1;
            string userInput = "";         

                GetValidInt("What is the index number you want to edit?", ref indexToEdit);
                indexToEdit-=1;

                GetValidItem("What is the new item?", theList, ref userInput);
                                         
                // Citation:
                //      https://stackoverflow.com/questions/17188966/how-to-replace-list-item-in-best-way
                //      The below code line replaces a specific index in the list with a new input variable 
                
                theList.RemoveAt(indexToEdit);
                theList.Insert(indexToEdit, userInput.ToString());
                Console.WriteLine("Done!");
        }
        
        public static void EditByName(List<string> theList)
        {
            int indexToEdit;
            string userInput = "";
            string nameToEdit = "";

            Console.WriteLine("What item name do you want to edit?");
            nameToEdit = CleanUpInput(Console.ReadLine());

            if (!theList.Contains(nameToEdit))
            {
                Console.WriteLine("That item is not on your list!");
            }
            else
            {
                indexToEdit = theList.IndexOf(nameToEdit);
                GetValidItem("What is the new item?", theList, ref userInput);

                // Citation:
                //      https://stackoverflow.com/questions/17188966/how-to-replace-list-item-in-best-way
                //      The below code line replaces a specific index in the list with a new input variable 

                theList.RemoveAt(indexToEdit);
                theList.Insert(indexToEdit, userInput.ToString());
                Console.WriteLine("Done!");
            }
        }

        // Citation:
        //      https://www.geeksforgeeks.org/ref-in-c-sharp/
        //      The ref keyword allows us to modify the value of the original variable
        public static void DecideByIndexOrName(string toDo, ref int toDoVariable)
       {
            GetValidInt($"Do you want to {toDo} by:\n  1. index \n  2. name\n(enter the corresponding number)", ref toDoVariable);
       }

        // Citation:
        //      https://www.dotnetperls.com/streamwriter
        //      The below block of code takes in a list and using TextWriter (tw), it goes line-by-line with a foreach loop, adding each line into a new StreamWriter file that it saves as MyAwesomeToDoList.txt
        public static void SaveFile(List<string> theList)
        {
            Console.WriteLine("Name your new To-Do list:");
            string saveAs = CleanUpInput(Console.ReadLine())+".txt";
            string saveLocation = "C://Users/krisz/OneDrive/TECHCareers/Code/c-assignment-crud-KrisztinaPap/bin/";
            TextWriter tw = new StreamWriter(saveLocation+saveAs);

            foreach (String s in theList)
            tw.WriteLine(s);

            tw.Close();
            Console.WriteLine("Your to-do list has been saved as '{0}' in your 'bin' folder.", saveAs);
        }  

        public static void ImportFile(List<string> theList)
        {
            Console.WriteLine("Enter the name of your text file without the extension (make sure it's in your project bin folder):");
            var fileName = CleanUpInput(Console.ReadLine());
            var fileWithPath = "C://Users/krisz/OneDrive/TECHCareers/Code/c-assignment-crud-KrisztinaPap/bin/"+fileName+".txt";

            // Citation:
            //      https://docs.microsoft.com/en-us/dotnet/api/system.io.file.exists?view=netcore-3.1
            //      The below line of code checks if the file exists
            if (File.Exists(fileWithPath))
            {
                // Citation:
                //      https://www.dotnetperls.com/streamreader
                //      Reads in a file line-by-line, and stores it all in a List.
                using (StreamReader reader = new StreamReader(fileWithPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        theList.Add(line); // Add to list.
                        Console.WriteLine("Your list has been successfully imported.");
                    }
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
    }
}