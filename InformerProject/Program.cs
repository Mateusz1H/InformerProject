using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformerProject
{
    internal class Program
    {
        private static string ConfigurationFile = "Config.cfg";
        static void Main(string[] args)
        {
            //GetFilesFromDirectory();
            CreateConfig();
            Console.ReadKey();
        }

        public static void GetFilesFromDirectory()
        {
            string PathFolder = Directory.GetCurrentDirectory();                                             //folder w którym znajdują się pliki
            string[] GetFilesFromDir = Directory.GetFiles(PathFolder);                       //lista plików w folderze
            for (int i = 0; i < GetFilesFromDir.Length; i++)
            {
                string FileName = Path.GetFileName(GetFilesFromDir[i]);
                Console.WriteLine(FileName);
                var LastModify = File.GetLastWriteTime(GetFilesFromDir[i]);                          //Pobranie danych o ostatniej modyfikacji pliku
                Console.WriteLine(LastModify);
            }

        }
        
        
        static void CreateConfig()
        {
            if (File.Exists(ConfigurationFile))
            {
                File.ReadAllLines(ConfigurationFile);
            }
            else
            {
                //File.Create(ConfigurationFile);
                File.OpenWrite(ConfigurationFile);
                File.ReadAllLines(ConfigurationFile);
            }
        }
    }
}
