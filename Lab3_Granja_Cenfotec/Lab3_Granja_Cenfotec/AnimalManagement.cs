using AccesoDatos.Crud;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3_Granja_Cenfotec
{
    public class AnimalManagement
    {
        private AnimalCrudFactory crudAnimal;

        public AnimalManagement()
        {
            crudAnimal = new AnimalCrudFactory();
        }

        public void Create(Animal animal)
        {

            crudAnimal.Create(animal);

        }

        public List<Animal> RetrieveAll()
        {
            return crudAnimal.RetrieveAll<Animal>();
        }

        public Animal RetrieveById(Animal animal)
        {
            return crudAnimal.Retrieve<Animal>(animal);
        }

        public Animal RetrieveByName(Animal animal)
        {
            return crudAnimal.RetrieveName<Animal>(animal);
        }

        public List<Animal> RetrieveByCategory(Animal animal)
        {
            return crudAnimal.RetrieveCategory<Animal>(animal);
        }

        internal void Update(Animal animal)
        {
            crudAnimal.Update(animal);
        }
        public void Delete(Animal animal)
        {
            crudAnimal.Delete(animal);
        }
    }
}
