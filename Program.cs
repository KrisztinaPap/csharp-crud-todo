using System;
// Citation
//      https://www.youtube.com/watch?reload=9&v=RQ0JHMGiobo&feature=youtu.be
//      The below Collection is necessary to work with lists
using System.Collections.Generic;

namespace c_assignment_crud_KrisztinaPap
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                Title: C# Assignment - CRUD
                Problem/Purpose: Practicing decisions, iteration, and data structures in C#. This application allows the user to create and manipulate a list with 10 string items.
                Author: Krisztina Pap
                Date of last edit: August 12, 2020
            */

            // Declare variables
            int userAction = -1; // The number of the menu item (action) the user chooses

            // Citation:
            //      https://www.youtube.com/watch?reload=9&v=RQ0JHMGiobo&feature=youtu.be
            //      The below line of code initializes an empty string list
            List<string> userList = new List<string> ();


            // Explains to user what the program does and how to use it
            Console.WriteLine("This program allows you to create and maintain a list of ten words (like a to-do list!)");

            // Loop to continue showing user the main menu until they choose option 5 to quit
            while ( userAction != 5 )
            {
                // Shows user program menu and wait for input
                Console.WriteLine("What would you like to do?\n-----------------------------\n1. Add a new item\n2. Delete an item\n3. Edit an item\n4. See the list\n5. Quit program");
                userAction = int.Parse(Console.ReadLine());
            }

            
/*        

            -- Read in integer input (myAction)
                - Validate myAction (int, 1-5)

            -- 1. Add new item
                Is the list full? (list.length == 10)
                 -- Yes: Throw warning and go back to menu
                 -- No: Prompt user for string and save it in newItem
                Validate new entries (!= "", must be string)
                Check for duplicates!
                Use .ToLower() and .Trim() on each new item
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
            4. Show list
                For loop to display items (index +1 for easy viewing!)
            5. Quit program 
                Sentinel loop (while action != 5)


            Ideas for unique features:
            -- Delete and update options don't show if list is empty
            -- Add option doesn't show when list is full
            -- Add an option to format list output (sub-menu with .ToUpper() and .ToLower())
            -- Add an option to reorder items? (Must research this one!)
            */



        }
    }
}