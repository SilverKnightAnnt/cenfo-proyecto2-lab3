using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AccesoDatos.Dao
{
    public class SqlOperation
    {
       
        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set; }


        public SqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }

       
        public void AddVarcharParam(string paramName, string paramValue)
        {
            var param = new SqlParameter("@p" + paramName, SqlDbType.VarChar)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

       
        public void AddIntParam(string paramName, int paramValue)
        {
            var param = new SqlParameter("@p" + paramName, SqlDbType.Int)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        
        public void AddDoubleParam(string paramName, double paramValue)
        {
            var param = new SqlParameter("@p" + paramName, SqlDbType.Decimal)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

    }
}
