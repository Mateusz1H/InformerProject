using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformerProject
{

    //ConfigurationFile - Ta zmienna jest nie potrzebna, będziemy kożystać ze standardowego mechanizmu do konfiguracji 
    //Nie widzę drugiego projektu o którym rozmawialiśmy, biblioteki z funkcjami aplikacji, logika (rdzeń systemu) powinna być odseparowana od interfejsu użytkownika 

    //Nie widzę jeszcze żadnych klas, obiektów?

    //Proszę o zmianę nazwę solucji:
    //Przjmujemy konwencję:
    //Solucja będzie nazwyać się "chmura24.ServiceUpdater"
    //Projekty kolejno:
    //1. chumra24.ServiceUpdater.Core - projekt, biblioteka narzędziowa z funkcjami projektu 
    //2. chmura24.ServiceUpdater.Service - aplikacja konsolowa wykonująca funkcje narzędziowe z projektu Core. 
    //   Aplikacja ta ma mieć możliwość uruchomienia w trybie usługi. Do zrobienia w przyszłości.

    internal class Program
    {
        private static string ConfigurationFile = "Config.cfg";                                     //przyjecie nazwy konfiguracyjnej pliku

        static void Main(string[] args)
        {
            GetPath();
            Console.ReadKey();
        }



        static void GetPath()                                                                       //metoda dzieki której sprawdzimy oraz wczytamy sciezke katologowa 
        {
            string DirectoryPath;                                                                   //zmienna dzieki ktorej przechowamy informacje dot. sciezki folderu
            Console.Write("Podaj sciezke dostępu do plików: ");
            DirectoryPath = Console.ReadLine();                                                     //wprowadzenie sciezki przez konsole
            if (string.IsNullOrEmpty(DirectoryPath))                                                //instrukcja sprawdzenia czy sciezka nie jest pusta
            {
                Console.WriteLine("Prosze podac sciezke");
                GetPath();                                                                          //powrot do metody GetPath();
            }
            else
            {                                 
                if (Directory.Exists(DirectoryPath) == false)                                       //instrukcja sprawdzajaca czy dana sciezka istnieje
                {
                    Console.WriteLine("Prosze podac poprawna sciezke lub ją utworzyć");
                    GetPath();
                }
                else
                {
                    Console.WriteLine("sciezka {0} wczytana pomyślnie!", DirectoryPath);            //wczytanie sciezki oraz wyswietlenie jej w konsoli
                    GetFilesFromDirectory(DirectoryPath);                                           //wczytanie metody pozwalajacej wczytac pliki z podanej przez uzytkownika sciezki
                    Console.ReadKey();
                }
            }
        }


        static void GetFilesFromDirectory(string PathFolder)                                                           
        {                                            
            string[] GetFilesFromDir = Directory.GetFiles(PathFolder);                              //lista plików w folderze
            for (int i = 0; i < GetFilesFromDir.Length; i++)                                        //instrukcja sprawdzajaca ile plikow jest w danym katalogu
            {
                string FileName = Path.GetFileName(GetFilesFromDir[i]);                             //Pobranie danych do zmiennej o nazwie pliku
                var LastModify = File.GetLastWriteTime(GetFilesFromDir[i]);                         //Pobranie danych do zmiennej o ostatniej modyfikacji pliku
                Console.WriteLine("{0} {1}", FileName, LastModify);                                 //wyswietlanie kolejno plików z katologu oraz ostatniej modyfikacji
                                                                                                    
            }

        }


        static void CreateConfig()   //to do: utworzenie pliku konfiguracyjnego
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
