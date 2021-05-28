using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test
{
    public class TaskManagment
    {
        public static Task CercaTask(ArrayList listaTask)
        {
            Console.WriteLine("Qual è il nome del task che vuoi eliminare?");
            string nome = Console.ReadLine();

            foreach (Task item in listaTask)
            {
                if (item.Nome == nome)
                {
                    return item;
                }
            }
            return null; //se ho ciclato su tutta la lista e non trovo nulla
        }

        public static ArrayList Filtro(ArrayList listaTask)
        {
            ArrayList taskFiltrati = new ArrayList();
            Console.WriteLine("Secondo quale grado di importanza vuoi filtrare?");
            string selezione = Console.ReadLine();

            foreach (Task item in listaTask)
            {
                if ("item.Importanza" == selezione)
                {
                    taskFiltrati.Add(item);
                }

            }

            return taskFiltrati;
        }

        public static void StampaListaFiltrataASchermo(ArrayList taskFiltrati)
        {
         foreach(Task item in taskFiltrati)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
