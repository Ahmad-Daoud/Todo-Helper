using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.Json;
using JSONManip;

namespace SimpleMenu
{
    public class MainMenu
    {
        private static TodoList todoList;
        public static void Menu()
        {
            Console.Clear();
            WriteLogo();
            Say("1", "Open todo-list");
            Say("2", "Edit an Element");
            Say("3", "Add an Element");
            Say("4", "Remove an Element");
            Say("5", "Empty Todo-List");
            string choice1 = Console.ReadLine();
            choice_decision(choice1);
        }

        public static void choice_decision(string choice){
            if (choice == "1") {
                Console.WriteLine ("Opening Todo List...");
                todoList = JsonExtr.ReadJsonFile();
                DisplayTodoList(todoList);
                Console.ReadKey();
            }
            else if(choice == "2") {
                // Edit Element
                Console.ReadKey();
            }
            else if(choice == "3"){
                // Add Element
                Console.ReadKey();
            }
            else if (choice == "4"){
                // Remove Element
                Console.Write("Please select the id of the element you wish to remove : ");
                string choice2 = Console.ReadLine();
                remove_element(choice2);
            }
            else if (choice == "5"){
                // Delete Todo-List
                Console.ReadKey();
            }
            else{
                Console.WriteLine("Please choose a valid option");
                choice = Console.ReadLine();
                choice_decision(choice);
            }
        }
        public static void Say(string Prefix, string message)
        {
            Console.Write("[");
            Console.Write(Prefix);
            Console.WriteLine("]" + message);
        }

        public static void remove_element(string choice){
            Console.WriteLine("Removed element #" + choice);
            // Remove Element
            Console.ReadKey();
        }
        public static void write_element(){
            Console.WriteLine("What is your element's name?");
            string element_name = Console.ReadLine();
            Console.WriteLine("What is your Element's Name");
            string element_description = Console.ReadLine();
        }
        public static void WriteLogo(){
            string logo = @"___________        .___          ___ ___         .__                       
\__    ___/___   __| _/____     /   |   \   ____ |  | ______   ___________ 
  |    | /  _ \ / __ |/  _ \   /    ~    \_/ __ \|  | \____ \_/ __ \_  __ \
  |    |(  <_> ) /_/ (  <_> )  \    Y    /\  ___/|  |_|  |_> >  ___/|  | \/
  |____| \____/\____ |\____/____\___|_  /  \___  >____/   __/ \___  >__|   
                    \/    /_____/     \/       \/     |__|        \/       ";
                    Console.WriteLine(logo);
        }




        public static void DisplayTodoList(TodoList todoList)
        {
            if (todoList != null)
            {
                foreach (var todo in todoList.Todos)
                {
                    Console.WriteLine("Id: " + todo.Id);
                    Console.WriteLine("Title: " + todo.Title);
                    Console.WriteLine("Due Date: " + todo.DateDue);
                    Console.WriteLine("Description: " + todo.Description);
                    Console.WriteLine("Category: " + todo.Category);
                    Console.WriteLine(); // Add a line break for separation
                }
            }
            else
            {
                Console.WriteLine("The to-do list is empty or could not be loaded.");
            }
        }

    }
}
