using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.Test
{
    public enum Impo
    {
        Basso,
        Medio,
        Alto
    }

    public class Task
    {
        public String Descrizione { get; set; }
        public String Nome { get; set; }
        public DateTime Scadenza { get; set; }
        public Impo Importanza { get; set; }

        

        public override string ToString()
        {
            return $"Descrizione: {Descrizione}\nScadenza: {Scadenza.ToShortDateString()}\nImportanza: {Importanza}";
        }
    }

    
}
