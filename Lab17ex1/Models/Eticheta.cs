using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17ex1.Models
{
    public class Eticheta
    {
        public int Id { get; set; }
        public Guid CodDeBare { get; set; }
        public double Pret { get; set; }
        public List<Produs> Produse { get; set; }

    }
}
