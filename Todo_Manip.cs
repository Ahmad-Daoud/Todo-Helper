using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace JSONManip
{
    public class TodoItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("date_due")]
        public string DateDue { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }
    }

    public class TodoList
    {
        [JsonPropertyName("todos")]
        public List<TodoItem> Todos { get; set; }
    }

    public class JsonExtr
    {
        public static TodoList ReadJsonFile(){
            string jsonFilePath = "./data/data.json";
            {
                try
                {
                    string jsonString = File.ReadAllText(jsonFilePath);
                    TodoList todoList = JsonSerializer.Deserialize<TodoList>(jsonString);
                    return todoList;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur lors de la lecture du fichier .JSON :  " + e.Message);
                    return null;
                }
            }
        }
    }
}