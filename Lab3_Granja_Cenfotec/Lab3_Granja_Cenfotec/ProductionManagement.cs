using AccesoDatos.Crud;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Granja_Cenfotec
{
    class ProductionManagement
    {
        private ProductionCrudFactory crudProduction;

        public ProductionManagement()
        {
            crudProduction = new ProductionCrudFactory();
        }

        public void Create(Produccion production)
        {

            crudProduction.Create(production);

        }

        public List<Produccion> RetrieveAll()
        {
            return crudProduction.RetrieveAll<Produccion>();
        }

        public Produccion RetrieveById(Produccion production)
        {
            return crudProduction.Retrieve<Produccion>(production);
        }

        public List<Produccion> RetrieveByDateRange(DateTime fechaInicio, DateTime fechaFin)
        {
            return crudProduction.RetrieveByDateRange<Produccion>(fechaInicio, fechaFin);
        }

        public List<Produccion> RetrieveByDateRangeAnimalCategory(DateTime fechaInicio, DateTime fechaFin, String categoria)
        {
            return crudProduction.RetrieveByDateRangeAnimalCategory<Produccion>(fechaInicio, fechaFin, categoria);
        }

        internal void Update(Produccion production)
        {
            crudProduction.Update(production);
        }
        public void Delete(Produccion production)
        {
            crudProduction.Delete(production);
        }
    }
}
