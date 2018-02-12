using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Produccion : BaseEntity
    {
        public int IdProduccion { get; set; }
        public DateTime FechaProduccion { get; set; }
        public String Tipo { get; set; }
        public double Cantidad { get; set; }
        public double Valor { get; set; }
        public int IdAnimal { get; set; }
        
        public Produccion()
        {

        }
    }
}
