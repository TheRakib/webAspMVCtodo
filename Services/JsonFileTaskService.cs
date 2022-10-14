using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using classwebsite.Model;
using Microsoft.AspNetCore.Hosting;

namespace classwebsite.Services
{
    public class JsonFileTaskService
    {

        //initilerar en web hosting environment 
        public JsonFileTaskService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
    
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "Data", "tasks.json");

        public IEnumerable<Task> GetTasks()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Task[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }



    }
}

