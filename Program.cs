using System;

namespace c_assignment_crud_KrisztinaPap
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
                Title: C# Assignment CRUD
                Problem/Purpose: Practicing decisions, iteration, and data structures in C#. This application allows the user to create and manipulate a list with 10 items.
                Author: Krisztina Pap
                Date of last edit: August 12, 2020
            */

/*        -- Declare variables

          -- Explain to user what the program does and how to use it

            -- Show the user program menu and wait for input
                1. Add new item
                2. Delete an item
                3. Edit an item
                4. Show list
                5. Quit program

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