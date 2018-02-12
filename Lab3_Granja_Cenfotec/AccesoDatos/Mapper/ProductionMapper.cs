using Entidades;
using AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Mapper
{
    public class ProductionMapper : EntityMapper, ISqlStaments, IObjectMapper
    {
        private const string DB_COL_ID_PRODUCCION = "id_produccion";
        private const string DB_COL_TIPO = "tipo";        
        private const string DB_COL_CANTIDAD = "cantidad";
        private const string DB_COL_VALOR = "valor";
        private const string DB_COL_ANIMAL = "id_animal";
        private const string DB_COL_FECHA_PRODUCCION = "fecha_produccion";


        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PA_CREAR_PRODUCCION" };

            var p = (Produccion)entity;
            operation.AddVarcharParam(DB_COL_TIPO, p.Tipo);
            operation.AddDoubleParam(DB_COL_CANTIDAD, p.Cantidad);
            operation.AddDoubleParam(DB_COL_VALOR, p.Valor);
            operation.AddVarcharParam(DB_COL_FECHA_PRODUCCION, p.FechaProduccion.ToString());
            operation.AddIntParam(DB_COL_ANIMAL, p.IdAnimal);

            return operation;
        }   

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PA_LISTAR_PRODUCCION_POR_ID" };

            var p = (Produccion)entity;
            operation.AddIntParam(DB_COL_ID_PRODUCCION, p.IdProduccion);

            return operation;
        }

        public SqlOperation GetRetriveDateRangeStatement(DateTime fechaInicio, DateTime fechaFin)
        {
            var operation = new SqlOperation { ProcedureName = "PA_LISTAR_PRODUCCION_POR_RANGO_FECHAS" };
                       
            operation.AddVarcharParam("fecha_inicio", fechaInicio.ToString());
            operation.AddVarcharParam("fecha_fin", fechaFin.ToString());

            return operation;
        }

        public SqlOperation GetRetriveDateRangeAnimalCategoryStatement(DateTime fechaInicio, DateTime fechaFin, String categoria)
        {
            var operation = new SqlOperation { ProcedureName = "PA_LISTAR_PRODUCCION_POR_RANGO_FECHAS_Y_TIPO" };

            
            operation.AddVarcharParam("fecha_inicio", fechaInicio.ToString());
            operation.AddVarcharParam("fecha_fin", fechaFin.ToString());
            operation.AddVarcharParam("categoria", categoria);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "PA_LISTAR_PRODUCCION" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PA_MODIFICAR_PRODUCCION" };

            var p = (Produccion)entity;
            operation.AddIntParam(DB_COL_ID_PRODUCCION, p.IdProduccion);
            operation.AddVarcharParam(DB_COL_TIPO, p.Tipo);
            operation.AddDoubleParam(DB_COL_CANTIDAD, p.Cantidad);
            operation.AddDoubleParam(DB_COL_VALOR, p.Valor);
            operation.AddVarcharParam(DB_COL_FECHA_PRODUCCION, p.FechaProduccion.ToString());
            operation.AddIntParam(DB_COL_ANIMAL, p.IdAnimal);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "PA_ELIMINAR_PRODUCCION" };

            var p = (Produccion)entity;
            operation.AddIntParam(DB_COL_ID_PRODUCCION, p.IdProduccion);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var production = BuildObject(row);
                lstResults.Add(production);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var produccion = new Produccion
            {
                IdProduccion = GetIntValue(row, DB_COL_ID_PRODUCCION),
                Tipo = GetStringValue(row, DB_COL_TIPO),
                FechaProduccion = GetDateValue(row, DB_COL_FECHA_PRODUCCION),
                Cantidad = GetDoubleValue(row, DB_COL_CANTIDAD),
                Valor = GetDoubleValue(row, DB_COL_VALOR),
                IdAnimal = GetIntValue(row, DB_COL_ANIMAL)
                               
            };

            return produccion;
        }

    }
}
