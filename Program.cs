using System;
// Citation:
//     https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.contains?view=netcore-3.1
//     Need System.Linq to be able to use Contains
using System.Linq; 

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
            string newItem = ""; // Initializes new item variable the user wants to add to the list

            // Declares new array with 10 values, all set to empty strings at the start
            string[] userList = new string[10];


            // Explains to user what the program does and how to use it
            Console.WriteLine("Welcome to 'The Best To-Do List'! This program allows you to create and maintain a list of ten things to do.");

            // Loop to continue showing user the main menu until they choose option 5 to quit
            while ( userAction != 5 )
            {
                // Shows user program menu and wait for input
                Console.WriteLine("What would you like to do?\n-----------------------------\n1. Add a new item\n2. Delete an item\n3. Edit an item\n4. See the list\n5. Quit program");
                userAction = int.Parse(Console.ReadLine());

                // If user chooses 1. Add a new item
                if ( userAction == 1 )
                {
                    // User can only add a new item if the list is not full
                    if ( userList[9] != "" )

                    // Validate newItem - can't be a duplicate, can't be an empty string
                    while ( userList.Contains(newItem) || newItem == "" )
                    {
                        try
                        {
                            // Console.WriteLine("Enter the item you want to add:");
                            // newItem = Console.ReadLine().ToLower().Trim(); // user input gets converted to all lowercase and leading and trailing spaces get removed

                            GetValidString("Enter the item you want to add:", userList);

                            // userList.Add(newItem);
                            Console.WriteLine("The item '{0}' was added to your list.", newItem);

                            if ( userList.Contains(newItem) || newItem == "" )
                            {
                                throw new ArgumentException();
                            }
                        }  
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Enter the item you want to add:");
                            CleanUpInput(newItem); // user input gets converted to all lowercase and leading and trailing spaces get removed
                        }
                    }
                    
                }

                // If user chooses 2. Delete an item
                else if ( userAction == 2 )
                {
                    Console.WriteLine("You chose action #2");
                }

                // If user chooses 3. Edit an item
                else if ( userAction == 3 )
                {
                    Console.WriteLine("You chose action #3");
                }

                // If user chooses 4. See the list
                else if ( userAction == 4 )
                {
                    for (int i = 0; i <= userList.Length - 1; i++)
                        {
                            // using (i+1) so user doesn't see items zero-indexed 
                            Console.WriteLine( (i+1) + ". " + userList[i] );
                        }
                }

                else if ( userAction == 5 )
                {
                    Console.WriteLine("Thank you for using our program! Press enter to quit...");
                }

                // If user chooses anything but the menu options available (1-5)
                else
                {
                    Console.WriteLine("'{0}' is not a valid menu option. Please try again!", userAction); 
                }
            }

            
/*        

            -- 1. Add new item
                
                 -- Yes: Throw warning and go back to menu
                 -- No: 
                Validate new entries (!= "", must be string)
                Check for duplicates!
            
            -- 2. Delete an item
                Delete by index or itemName? 
                 -- by index: Prompt user for index and delete
                 -- by itemName: Prompt user for itemName and delete
                Use .ToLower() and .Trim() on each user input for searching
            3. Edit an item
                Edit by index or itemName?
                 -- by index: Prompt user for index and replace
                 -- by itemName: Prompt user for itemName and replace
                Validate new entries (!= "", must be string)
                Check for duplicates!
                Use .ToLower() and .Trim() on each user input for searching
                Use .ToLower() and .Trim() on each new item
    
       

            Ideas for unique features:
            -- Delete and update options don't show if list is empty
            -- Add option doesn't show when list is full
            -- Add an option to format list output (sub-menu with .ToUpper() and .ToLower())
            -- Add an option to reorder items? (Must research this one!)
            */

        }

        // Citation:
        // James Grieve C# lesson notes - validation methods
        // The below code block creates a method that takes in a prompt and an array
        // Starts by setting valid to false and newString to an empty string
        // Displays the prompt (input instructions to the user)
        // Saves user input in newString and tests it against conditions (duplicate? empty string? shorter than 2 characters?) - if so, throws and error and prompts again for input
        // If valid, method returns newString
        static string GetValidString(string thePrompt, string[] theArray)
        {
            bool valid = false;
            string newString = "";

            do
            {
                Console.WriteLine(thePrompt);
                try
                {
                    newString = Console.ReadLine();
                    CleanUpInput(newString);
                    if ( newString == "" || theArray.Contains(newString) || newString.Length < 2 )
                    {
                        throw new Exception("You can't add an empty string to your list!");
                    }
                    valid = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message}");
                }
            } while (!valid);
            
            return newString;
        }

        // A method to clean up user string input - trims whitespaces and converts to all lowercase
        static string CleanUpInput(string theInput)
        {
            string cleanInput = theInput.Trim().ToLower();
            return cleanInput;
        }

        
    }
}