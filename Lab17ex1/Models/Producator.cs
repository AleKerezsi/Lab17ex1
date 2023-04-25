using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17ex1.Models
{
    public class Producator
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public string CUI { get; set; }
        public List<Produs> Produse { get; set; }

    }
}
