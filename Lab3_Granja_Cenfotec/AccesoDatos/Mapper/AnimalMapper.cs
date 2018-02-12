using Entidades;
using AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Mapper
{
    public class AnimalMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_ANIMAL = "id_animal";
        private const string DB_COL_NOMBRE = "nombre";
        private const string DB_COL_CATEGORIA = "categoria";
        private const string DB_COL_EDAD = "edad";
        private const string DB_COL_FECHA_NACIMIENTO = "fecha_nacimiento";
        private const string DB_COL_ALIMENTO_FAVORITO = "alimento_favorito";
                     


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PA_CREAR_ANIMAL" };

            var a = (Animal)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, a.Nombre);
            operation.AddVarcharParam(DB_COL_CATEGORIA, a.Categoria);
            operation.AddVarcharParam(DB_COL_FECHA_NACIMIENTO, a.FechaNacimiento.ToString());
            operation.AddVarcharParam(DB_COL_ALIMENTO_FAVORITO, a.Alimento);
                        
            return operation;
        }


        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PA_LISTAR_ANIMAL_POR_ID" };

            var c = (Animal)entity;
            operation.AddIntParam(DB_COL_ID_ANIMAL, c.IdAnimal);

            return operation;
        }

        public SqlOperation GetRetriveNameStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PA_LISTAR_ANIMAL_POR_NOMBRE" };

            var c = (Animal)entity;
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);

            return operation;
        }

        public SqlOperation GetRetriveCategoryStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PA_LISTAR_ANIMAL_POR_TIPO" };

            var c = (Animal)entity;
            operation.AddVarcharParam(DB_COL_CATEGORIA, c.Categoria);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PA_LISTAR_ANIMALES" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PA_MODIFICAR_ANIMAL" };

            var a = (Animal)entity;
            operation.AddIntParam(DB_COL_ID_ANIMAL, a.IdAnimal);
            operation.AddVarcharParam(DB_COL_NOMBRE, a.Nombre);
            operation.AddVarcharParam(DB_COL_CATEGORIA, a.Categoria);
            operation.AddVarcharParam(DB_COL_FECHA_NACIMIENTO, a.FechaNacimiento.ToString());
            operation.AddVarcharParam(DB_COL_ALIMENTO_FAVORITO, a.Alimento);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PA_ELIMINAR_ANIMAL_POR_ID" };

            var c = (Animal)entity;
            operation.AddIntParam(DB_COL_ID_ANIMAL, c.IdAnimal);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var animal = BuildObject(row);
                lstResults.Add(animal);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var animal = new Animal
            {
                IdAnimal = GetIntValue(row, DB_COL_ID_ANIMAL),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Categoria = GetStringValue(row, DB_COL_CATEGORIA),
                Edad = GetIntValue(row, DB_COL_EDAD),
                FechaNacimiento = GetDateValue(row, DB_COL_FECHA_NACIMIENTO),
                Alimento = GetStringValue(row, DB_COL_ALIMENTO_FAVORITO)
            };

            return animal;
        }

    }
}
