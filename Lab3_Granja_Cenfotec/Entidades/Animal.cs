using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Animal : BaseEntity
    {
      
        public int IdAnimal { get; set; }
        public String Nombre { get; set; }
        public String Categoria { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Alimento { get; set; }

      
        public Animal()
        {

        }
    }
}
