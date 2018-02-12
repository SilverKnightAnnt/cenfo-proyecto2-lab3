using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Granja_Cenfotec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("----¡Bienvenido al sistema de la granja Cenfotec!----");
            MostrarMenu();
        }

        static void MostrarMenu()
        {
            int opcion = -1;
            while (opcion != 9)
            {
                
                Console.WriteLine();
                Console.WriteLine("----Menú principal----");
                Console.WriteLine();
                Console.WriteLine("1. Registrar animal.");
                Console.WriteLine("2. Listar animales.");
                Console.WriteLine("3. Modificar animal.");
                Console.WriteLine("4. Eliminar animal.");
                Console.WriteLine("5. Registrar producción.");
                Console.WriteLine("6. Listar producciones.");
                Console.WriteLine("7. Modificar producción.");
                Console.WriteLine("8. Eliminar producción.");
                Console.WriteLine("9. Salir.");
                Console.WriteLine();
                Console.WriteLine("Seleccione su opción: ");
                opcion = int.Parse(Console.ReadLine());
                Console.WriteLine();
                ProcesarOpcion(opcion);
            }
           
            
        }
        static void ProcesarOpcion(int pOpcion)
        {
            switch (pOpcion)
            {
                case 1:
                    RegistrarAnimal();
                    break;
                case 2:
                    MostrarMenuListaAnimales();
                    break;
                case 3:
                    ModificarAnimal();
                    break;
                case 4:
                    EliminarAnimal();
                    break;
                case 5:
                    RegistrarProduccion();
                    break;
                case 6:
                    MostrarMenuListaProduccion();
                    break;
                case 7:
                    ModificarProduccion();
                    break;
                case 8:
                    EliminarProduccion();
                    break;
                case 9:
                    break;
                default:
                    Console.WriteLine("Opción incorrecta.");
                    break;
            }
        }

        static void MostrarMenuListaAnimales()
        {
            int opcionLista = -1;
            if(opcionLista != 4)
            {
                Console.WriteLine();
                Console.WriteLine("----Seleccione el método de listado----");
                Console.WriteLine();
                Console.WriteLine("1. Listar por nombre.");
                Console.WriteLine("2. Listar por tipo.");
                Console.WriteLine("3. Listar todos los animales.");
                Console.WriteLine("4. Salir.");
                Console.WriteLine();
                Console.WriteLine("Seleccione su opción: ");
                opcionLista = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            switch (opcionLista)
            {
                case 1:
                    ListarAnimalesNombre();
                    break;
                case 2:
                    ListarAnimalesTipo();
                    break;
                case 3:
                    ListarAnimales();
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
        static void MostrarMenuListaProduccion()
        {
            int opcionProduccion = -1;
            if (opcionProduccion != 4)
            {
                Console.WriteLine();
                Console.WriteLine("----Seleccione el método de listado----");
                Console.WriteLine();
                Console.WriteLine("1. Listar por rango de fechas.");
                Console.WriteLine("2. Listar por rango de fechas y tipo de animal.");
                Console.WriteLine("3. Listar todas las producciones.");
                Console.WriteLine("4. Salir.");
                Console.WriteLine();
                Console.WriteLine("Seleccione su opción: ");
                opcionProduccion = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            switch (opcionProduccion)
            {
                case 1:
                    ListarProduccionRangoFechas();
                    break;
                case 2:
                    ListarProduccionRangoFechasTipoAnimal();
                    break;
                case 3:
                    ListarProduccion();
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }
        static AnimalManagement AnimalManage = new AnimalManagement();
        static ProductionManagement ProductManage = new ProductionManagement();

        static void RegistrarAnimal()
        {
            
            Animal animal = new Animal();
            Console.WriteLine();
            Console.WriteLine("Ingrese el nombre del animal: ");
            animal.Nombre = Console.ReadLine();
            Console.WriteLine("---Seleccione un tipo de animal---");
            Console.WriteLine();
            Console.WriteLine("1. Vaca.");
            Console.WriteLine("2. Chancho.");
            Console.WriteLine("3. Gallina.");
            Console.WriteLine();
            int tipo = int.Parse(Console.ReadLine());
            switch (tipo)
            {
                case 1:
                    animal.Categoria = "Vaca";
                    break;
                case 2:
                    animal.Categoria = "Chancho";
                    break;
                case 3:
                    animal.Categoria = "Gallina";
                    break;
            }
            Console.WriteLine("Ingrese la fecha de nacimiento (aaaa-mm-dd): ");
            animal.FechaNacimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el alimento favorito: ");
            animal.Alimento = Console.ReadLine();
            
            AnimalManage.Create(animal);
            Console.WriteLine();
            Console.WriteLine("Animal registrado.");

        }
        static void ListarAnimales()
        {            
            var animalList = AnimalManage.RetrieveAll();
            
           
                Console.WriteLine("ID \t | Nombre \t | Categoría \t | Edad \t | Fecha Nacimiento \t | Alimento favorito");
                foreach (var c in animalList)
                {
                    var date = c.FechaNacimiento.ToShortDateString();
                    Console.WriteLine(String.Format("{0} \t | {1} \t  | {2}  \t | {3} \t\t | {4} \t\t | {5}",
                        c.IdAnimal, c.Nombre, c.Categoria, c.Edad, date, c.Alimento));

                }
           
                        
        }
        static void ListarAnimalesNombre()
        {
            ListarAnimales();
            Console.WriteLine();
            Animal animal = new Animal();
            Console.WriteLine("Ingrese el nombre del animal que desea listar: ");
            animal.Nombre = Console.ReadLine();
            Console.WriteLine();

            var c = AnimalManage.RetrieveByName(animal);
                if(c != null)
            {
                Console.WriteLine("ID \t | Nombre \t | Categoría \t | Edad \t | Fecha Nacimiento \t | Alimento favorito");
                var date = c.FechaNacimiento.ToShortDateString();
                Console.WriteLine(String.Format("{0} \t | {1} \t  | {2}  \t | {3} \t\t | {4} \t\t | {5}",
                   c.IdAnimal, c.Nombre, c.Categoria, c.Edad, date, c.Alimento));
            }
            else
            {
                Console.WriteLine("El animal no se encuentra registrado.");
            }                        
           

        }
        static void ListarAnimalesTipo()
        {
            ListarAnimales();
            Console.WriteLine();
            Animal animal = new Animal();
            Console.WriteLine();
            Console.WriteLine("---Seleccione un tipo de animal---");
            Console.WriteLine();
            Console.WriteLine("1. Vaca.");
            Console.WriteLine("2. Chancho.");
            Console.WriteLine("3. Gallina.");
            Console.WriteLine();
            int tipo = int.Parse(Console.ReadLine());
            switch (tipo)
            {
                case 1:
                    animal.Categoria = "Vaca";
                    break;
                case 2:
                    animal.Categoria = "Chancho";
                    break;
                case 3:
                    animal.Categoria = "Gallina";
                    break;
            }            
            Console.WriteLine();

            var animalList = AnimalManage.RetrieveByCategory(animal);

            
            Console.WriteLine("ID \t | Nombre \t | Categoría \t | Edad \t | Fecha Nacimiento \t | Alimento favorito");
            foreach (var c in animalList)
            {
                var date = c.FechaNacimiento.ToShortDateString();
                Console.WriteLine(String.Format("{0} \t | {1} \t  | {2}  \t | {3} \t\t | {4} \t\t | {5}",
                    c.IdAnimal, c.Nombre, c.Categoria, c.Edad, date, c.Alimento));

            }

        }
        static void ModificarAnimal()
        {
            ListarAnimales();
            Console.WriteLine();
            Animal animal = new Animal();
            Console.WriteLine("Ingrese el ID del animal que desea modificar: ");
            animal.IdAnimal = int.Parse(Console.ReadLine());

            animal = AnimalManage.RetrieveById(animal);                

            if (animal != null)
            {               
                Console.WriteLine("Ingrese un nuevo nombre: ");
                animal.Nombre = Console.ReadLine();
                Console.WriteLine("---Seleccione una nueva categoría---");
                Console.WriteLine();
                Console.WriteLine("1. Vaca.");
                Console.WriteLine("2. Chancho.");
                Console.WriteLine("3. Gallina.");
                int tipo = int.Parse(Console.ReadLine());
                switch (tipo)
                {
                    case 1:
                        animal.Categoria = "Vaca";
                        break;
                    case 2:
                        animal.Categoria = "Chancho";
                        break;
                    case 3:
                        animal.Categoria = "Gallina";
                        break;
                }
                Console.WriteLine("Ingrese una nueva fecha de nacimiento (aaaa-mm-dd): ");
                animal.FechaNacimiento = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese un nuevo alimento favorito: ");
                animal.Alimento = Console.ReadLine();

                AnimalManage.Update(animal);
                Console.WriteLine();
                Console.WriteLine("Animal actualizado.");
            }
            else
            {
                Console.WriteLine("El animal no se encuentra registrado.");
            }

        }
        static void EliminarAnimal()
        {
            ListarAnimales();
            Console.WriteLine();
            Animal animal = new Animal();
            Console.WriteLine("Ingrese el ID del animal que desea eliminar: ");
            animal.IdAnimal = int.Parse(Console.ReadLine());
            Console.WriteLine();

            animal = AnimalManage.RetrieveById(animal);

            if (animal != null)
            {
                AnimalManage.Delete(animal);               
                Console.WriteLine("Animal eliminado.");
            }
            else
            {
                Console.WriteLine("El animal no se encuentra registrado.");
            }
        }

        static void RegistrarProduccion()
        {

            Produccion produccion = new Produccion();            
            Console.WriteLine();
            ListarAnimales();
            Console.WriteLine("Ingrese el ID del animal: ");
            produccion.IdAnimal = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de la producción (aaaa-mm-dd): ");
            produccion.FechaProduccion = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("---Seleccione el tipo de producción---");
            Console.WriteLine();
            Console.WriteLine("1. Leche. (Botellas)");
            Console.WriteLine("2. Carne. (Kilos)");
            Console.WriteLine("3. Huevos. (Unidades)");
            int tipo = int.Parse(Console.ReadLine());
            switch (tipo)
            {
                case 1:
                    produccion.Tipo = "Leche";
                    break;
                case 2:
                    produccion.Tipo = "Carne";
                    break;
                case 3:
                    produccion.Tipo = "Huevos";
                    break;
            }
            Console.WriteLine("Ingrese la cantidad: ");
            produccion.Cantidad = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el valor en cenfodolares: ");
            produccion.Valor = double.Parse(Console.ReadLine());


            ProductManage.Create(produccion);
            Console.WriteLine();
            Console.WriteLine("Producción registrada.");

        }

        static void ListarProduccion()
        {
            var productList = ProductManage.RetrieveAll();
            
            
            Console.WriteLine("ID \t | Nombre \t | Categoría \t | Tipo \t | Cantidad \t | Valor \t | Fecha producción");
            foreach (var c in productList)
            {
                Animal animal = new Animal();
                animal.IdAnimal = c.IdAnimal;
                var animalList = AnimalManage.RetrieveById(animal);
                var date = c.FechaProduccion.ToShortDateString();
                Console.WriteLine(String.Format("{0} \t | {1} \t  | {2}  \t | {3} \t | {4} \t\t | {5} \t\t | {6}",
                    c.IdProduccion, animalList.Nombre, animalList.Categoria, c.Tipo, c.Cantidad, c.Valor, date));

            }


        }

        static void ListarProduccionRangoFechas()
        {            
            Console.WriteLine();
            Produccion produccion = new Produccion();
            Console.WriteLine("Ingrese la fecha de inicio (aaaa-mm-dd): ");
            DateTime fechaInicio = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de fin (aaaa-mm-dd): ");
            DateTime fechaFin = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();

            var productList = ProductManage.RetrieveByDateRange(fechaInicio, fechaFin);

            if(productList != null)
            {
                Console.WriteLine("ID \t | Nombre \t | Categoría \t | Tipo \t | Cantidad \t | Valor \t | Fecha producción");
                foreach (var c in productList)
                {
                    Animal animal = new Animal();
                    animal.IdAnimal = c.IdAnimal;
                    var animalList = AnimalManage.RetrieveById(animal);
                    var date = c.FechaProduccion.ToShortDateString();
                    Console.WriteLine(String.Format("{0} \t | {1} \t  | {2}  \t | {3} \t | {4} \t\t | {5} \t\t | {6}",
                        c.IdProduccion, animalList.Nombre, animalList.Categoria, c.Tipo, c.Cantidad, c.Valor, date));

                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No se encontraron datos.");
            }         
            
        }

        static void ListarProduccionRangoFechasTipoAnimal()
        {
            Console.WriteLine();
            Produccion produccion = new Produccion();            
            Console.WriteLine("Ingrese la fecha de inicio (aaaa-mm-dd): ");
            DateTime fechaInicio = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de fin (aaaa-mm-dd): ");
            DateTime fechaFin = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("---Seleccione el tipo de animal---");
            Console.WriteLine();
            Console.WriteLine("1. Vaca.");
            Console.WriteLine("2. Chancho.");
            Console.WriteLine("3. Gallina.");
            Console.WriteLine();
            int tipo = int.Parse(Console.ReadLine());
            String categoria = "";
            switch (tipo)
            {
                case 1:
                    categoria = "Vaca";
                    break;
                case 2:
                    categoria = "Chancho";
                    break;
                case 3:
                    categoria = "Gallina";
                    break;
            }
            Console.WriteLine();

            var productList = ProductManage.RetrieveByDateRangeAnimalCategory(fechaInicio, fechaFin, categoria);

            if(productList != null)
            {
                Console.WriteLine("ID \t | Nombre \t | Categoría \t | Tipo \t | Cantidad \t | Valor \t | Fecha producción");
                foreach (var c in productList)
                {
                    Animal animal = new Animal();
                    animal.IdAnimal = c.IdAnimal;
                    var animalList = AnimalManage.RetrieveById(animal);
                    var date = c.FechaProduccion.ToShortDateString();
                    Console.WriteLine(String.Format("{0} \t | {1} \t  | {2}  \t | {3} \t | {4} \t\t | {5} \t\t | {6}",
                        c.IdProduccion, animalList.Nombre, animalList.Categoria, c.Tipo, c.Cantidad, c.Valor, date));

                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No se encontraron datos.");
            }
            
        }

        static void ModificarProduccion()
        {
            ListarProduccion();
            Console.WriteLine();
            Produccion produccion = new Produccion();
            Console.WriteLine("Ingrese el ID de la producción que desea modificar: ");
            produccion.IdProduccion = int.Parse(Console.ReadLine());

            produccion = ProductManage.RetrieveById(produccion);

            if (produccion != null)
            {
                ListarAnimales();
                Console.WriteLine();
                Console.WriteLine("Ingrese un nuevo ID de animal: ");
                produccion.IdAnimal = int.Parse(Console.ReadLine());                
                    Console.WriteLine("Ingrese una nueva fecha de la producción (aaaa-mm-dd): ");
                    produccion.FechaProduccion = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("---Seleccione el nuevo tipo de producción---");
                    Console.WriteLine();
                    Console.WriteLine("1. Leche. (Botellas)");
                    Console.WriteLine("2. Carne. (Kilos)");
                    Console.WriteLine("3. Huevos. (Unidades)");
                    int tipo = int.Parse(Console.ReadLine());
                    switch (tipo)
                    {
                        case 1:
                            produccion.Tipo = "Leche";
                            break;
                        case 2:
                            produccion.Tipo = "Carne";
                            break;
                        case 3:
                            produccion.Tipo = "Huevos";
                            break;
                    }
                    Console.WriteLine("Ingrese una nueva cantidad : ");
                    produccion.Cantidad = double.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese un nuevo valor en cenfodolares: ");
                    produccion.Valor = double.Parse(Console.ReadLine());

                    ProductManage.Update(produccion);
                    Console.WriteLine();
                    Console.WriteLine("Producción actualizada.");
               
            }
            else
            {
                Console.WriteLine("La producción no se encuentra registrada.");
            }

        }
        static void EliminarProduccion()
        {
            ListarProduccion();
            Console.WriteLine();
            Produccion produccion = new Produccion();
            Console.WriteLine("Ingrese el ID de la producción que desea eliminar: ");
            produccion.IdProduccion = int.Parse(Console.ReadLine());
            Console.WriteLine();

            produccion = ProductManage.RetrieveById(produccion);

            if (produccion != null)
            {
                ProductManage.Delete(produccion);
                Console.WriteLine("Producción eliminada.");
            }
            else
            {
                Console.WriteLine("La producción no se encuentra registrada.");
            }
        }
    }
}
