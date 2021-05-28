using System;
using System.Collections;

namespace Week2.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = TaskIO.InserisciPath();
            AnalizzaScelta(path);
        }

        public static void AnalizzaScelta(string path)
        {
            ArrayList listaTask = new ArrayList();
            bool prosegui = true;
            

            while (prosegui)
            {
                int scelta = MenuAzione();
                ArrayList taskFiltrati = new ArrayList();
                switch (scelta)
                {
                    case 0:
                        //al verificarsi dell'eccezione. Ripropone menu
                        break;
                    case 1:
                        //vedere i task dal file
                        TaskIO.LeggiDaFile(path);
                        break;
                    case 2:
                        //aggiunge un task alla lista e al file
                        listaTask = TaskIO.AggiungiTaskInFile(listaTask, path);
                        break;
                    case 3:
                        //cerca task per nome e lo elimina
                        Task taskSelezionato = TaskManagment.CercaTask(listaTask);
                        try
                        {
                            listaTask.Remove(taskSelezionato);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Task non trovato");
                        }
                        break;
                    case 4:
                        //filtrare task per impo
                        TaskManagment.Filtro(listaTask);
                        TaskManagment.StampaListaFiltrataASchermo(taskFiltrati);
                        break;
                    case 5:
                        //esce per inserimento da tastiera
                        Console.WriteLine("Arrivederci");
                        prosegui = false;
                        break;

                }
            }
            
        }

        

        public static int MenuAzione()
        {
                Console.WriteLine("1. Vedi i Task inseriti nel file\n2. Aggiungi un nuovo Task al file\n" +
                    "3. Elimina un Task\n4. Filtra Task per importanza\n5. Esci");
                int scelta = 0;
                try
                {
                    scelta = Convert.ToInt32(Console.ReadLine());
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    scelta = 0;
                }
                return scelta;
        }
    }
}
