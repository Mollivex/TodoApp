using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TodoApp.Models;

namespace TodoApp.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<TodoModel> LoadData()
        {
            // verify if file exists on the defined PATH
            var fileExists = File.Exists(PATH);
            if(!fileExists)
            {
                // if file doesn't exists, we create this file on this PATH and call Dispose() method
                File.CreateText(PATH).Dispose();
                // return empty binding list model
                return new BindingList<TodoModel>();
            }
            // reading data from file using OpenText() method
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                // deserialize file data using DeserializeObject<BindingList<>>() and return
                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(fileText);
            }
        }

        /// <summary>
        /// Save data from rows in file
        /// </summary>
        /// <param name="todoDataList"></param>
        public void SaveData(object todoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }
        }
    }
}
