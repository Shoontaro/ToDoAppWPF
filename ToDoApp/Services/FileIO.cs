using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    internal class FileIO
    {
        private readonly string PATH;

        public FileIO(string pATH)
        {
            PATH = pATH;
        }

        public BindingList<ToDoModel> LoadData() {

            var fileExists = File.Exists(PATH);
            if (!fileExists) {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }

            using (var reader = File.OpenText(PATH)) {
            var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);
            }

        }

        public void SaveData(object todoDataList) {

            using (StreamWriter writer = File.CreateText(PATH)) 
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }

        }
    }
}
