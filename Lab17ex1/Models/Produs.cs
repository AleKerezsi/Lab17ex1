using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17ex1.Models
{
    public class Produs
    {
        public int Id { get; set; }
        public string Nume { get; set; }

        public int Stoc { get; set; }

        public Producator Producator { get; set; }

        public Categorie Categorie { get; set; }

        public Eticheta Eticheta { get; set; }
    }
}
