using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test
{
    public class TaskIO
    {

        public static string InserisciPath()
        {
            Console.WriteLine("Come si chiama la cartella del file che vuoi leggere?");
            string nomeCartella = Console.ReadLine();
            string path = TaskIO.ControlloPath(nomeCartella);
            return path;
        }

        public static string ControlloPath(string nomeCartella)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                nomeCartella);
            if (!Directory.Exists(path))
            {
                DirectoryInfo directory = new DirectoryInfo(path);
                directory.Create();
                Console.WriteLine("Non esiste una cartella nella directory selezionata. " +
                    "Ho creato una cartella vuota in:\n {0}", path);   
            }
            return path;
        }

        public static ArrayList AggiungiTaskInFile(ArrayList listaTask, string path)
        {
            Task task = new Task();
            try
            {
                bool success;
                Console.WriteLine("Inserisci Descrizione");
                task.Descrizione = Console.ReadLine();
                Console.WriteLine("Inserisci nome");
                task.Nome = Console.ReadLine();
                Console.WriteLine("Inserisci scadenza");
                
                bool prova = DateTime.TryParse(Console.ReadLine(), out DateTime scadenza);
                while (!prova)
                {
                    Console.WriteLine("Inserisci un valore corretto");
                    prova = DateTime.TryParse(Console.ReadLine(), out scadenza);
                }
                int verificaScadenza = DateTime.Compare(scadenza, DateTime.Today);
                if (verificaScadenza<0)
                {
                    Console.WriteLine("Non puoi avere una data di scadenza più vecchia di oggi. Inseriscila di nuovo");
                    bool prova1 = DateTime.TryParse(Console.ReadLine(), out DateTime scadenza1);
                    while (!prova1)
                    {
                        Console.WriteLine("Inserisci un valore corretto");
                        prova1 = DateTime.TryParse(Console.ReadLine(), out scadenza1);
                    }
                    task.Scadenza = scadenza1;
                }
                else
                {
                    task.Scadenza = scadenza;
                }
                
                Console.WriteLine("Inserisci importanza");
                //stampa valori enum
                int[] values = new int[] { 0, 1, 2 };
                foreach (int enumValue in values)
                {
                    Console.WriteLine(Enum.GetName(typeof(Impo), enumValue));
                }
                success = Enum.TryParse(Console.ReadLine(), out Impo impo);
                task.Importanza = impo;
                listaTask.Add(task);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }         

            try
            {
                using (StreamWriter writer = File.CreateText(path))
                {
                    foreach (Task item in listaTask)
                    {
                        writer.WriteAsync(task.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return listaTask;

        }


        public static void LeggiDaFile(string path)
        { 
            string line;
            try
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    //finché c'è info nel file la leggo e la metto in line
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
