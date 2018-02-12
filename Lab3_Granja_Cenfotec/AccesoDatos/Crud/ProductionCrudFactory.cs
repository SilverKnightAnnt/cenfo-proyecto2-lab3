using Entidades;
using AccesoDatos.Mapper;
using AccesoDatos.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Crud
{
    public class ProductionCrudFactory : CrudFactory
    {
        ProductionMapper mapper;

        public ProductionCrudFactory() : base()
        {
            mapper = new ProductionMapper();
            Dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var produccion = (Produccion)entity;
            var sqlOperation = mapper.GetCreateStatement(produccion);
            Dao.ExecuteProcedure(sqlOperation);
        }       

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = Dao.ExecuteQueryProcedure(mapper.GetRetriveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public List<T> RetrieveByDateRange<T>(DateTime fechaInicio, DateTime fechaFin)
        {
            var lstProducts = new List<T>();

            var lstResult = Dao.ExecuteQueryProcedure(mapper.GetRetriveDateRangeStatement(fechaInicio, fechaFin));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProducts.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProducts;
        }

        public List<T> RetrieveByDateRangeAnimalCategory<T>(DateTime fechaInicio, DateTime fechaFin, String categoria)
        {
            var lstProducts = new List<T>();

            var lstResult = Dao.ExecuteQueryProcedure(mapper.GetRetriveDateRangeAnimalCategoryStatement(fechaInicio, fechaFin, categoria));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProducts.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProducts;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstProduction = new List<T>();

            var lstResult = Dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstProduction.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstProduction;
        }        

        public override void Update(BaseEntity entity)
        {
            var production = (Produccion)entity;
            Dao.ExecuteProcedure(mapper.GetUpdateStatement(production));
        }
        public override void Delete(BaseEntity entity)
        {
            var production = (Produccion)entity;
            Dao.ExecuteProcedure(mapper.GetDeleteStatement(production));
        }
    }
}
