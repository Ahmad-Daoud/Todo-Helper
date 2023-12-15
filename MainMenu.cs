using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.Json;
using JSONManip;
using elementRemoval;

namespace SimpleMenu
{
    public class MainMenu
    {
        private static TodoList todoList;
        public static void Menu()
        {
            Console.Clear();
            WriteLogo();
            Say("1", "Afficher la Todo-List");
            Say("2", "Modifier un élément");    
            Say("3", "Ajouter un élément");
            Say("4", "Supprimer un élément");
            Say("5", "Vider la Todo-List");
            string menuChoice = Console.ReadLine();
            choice_decision(menuChoice);
        }
        public static void choice_decision(string choice){
            if (choice == "1") {
                Console.WriteLine ("Ouverture de la Todo-List...");
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
                Console.Write("Veuillez choisir l'ID de l'élément à supprimer : ");
                string choiceRemove = Console.ReadLine();
                remove_element(choiceRemove);
            }
            else if (choice == "5"){
                // Delete Todo-List
                Console.ReadKey();
            }
            else{
                Console.WriteLine("Veuillez choisir une option valide");
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
            Console.WriteLine(" Suppression de l'élément #" + choice + "... \n ");
            // Remove Element
            Console.ReadKey();
        }
        public static void write_element(){
            Console.WriteLine("Quel est le nom de votre élément?");
            string element_name = Console.ReadLine();
            Console.WriteLine("Quelle est la description de votre élément");
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
                    Console.WriteLine(); // Write Line pour séparer les éléments
                }
            }
            else
            {
                Console.WriteLine("La Todo-List est vide ou introuvable.");
            }
        }
    }
}
