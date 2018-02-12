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
    public class AnimalCrudFactory : CrudFactory
    {
        AnimalMapper mapper;

        public AnimalCrudFactory() : base()
        {
            mapper = new AnimalMapper();
            Dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var animal = (Animal)entity;
            var sqlOperation = mapper.GetCreateStatement(animal);
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

        public T RetrieveName<T>(BaseEntity entity)
        {
            var lstResult = Dao.ExecuteQueryProcedure(mapper.GetRetriveNameStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public List<T> RetrieveCategory<T>(BaseEntity entity)
        {
            var lstAnimals = new List<T>();

            var lstResult = Dao.ExecuteQueryProcedure(mapper.GetRetriveCategoryStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAnimals.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAnimals;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstAnimals = new List<T>();

            var lstResult = Dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstAnimals.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstAnimals;
        }

        public override void Update(BaseEntity entity)
        {
            var animal = (Animal)entity;
            Dao.ExecuteProcedure(mapper.GetUpdateStatement(animal));
        }
        public override void Delete(BaseEntity entity)
        {
            var animal = (Animal)entity;
            Dao.ExecuteProcedure(mapper.GetDeleteStatement(animal));
        }
    }
}
