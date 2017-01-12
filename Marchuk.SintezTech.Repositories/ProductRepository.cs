using Dapper;
using Marchuk.SintezTech.Core.Models;
using Marchuk.SintezTech.Models;
using Marchuk.SintezTech.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marchuk.SintezTech.Repositories
{
    public class ProductRepository : IGenericRepository<SintezProduct>
    {
        public void Add(SintezProduct product)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.CONNECTIONSTRING].ConnectionString))
            {
                db.Execute("addProduct", param: product, commandType: CommandType.StoredProcedure);
            }
        }

        public SintezProduct Get(int id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.CONNECTIONSTRING].ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@id", id);

                return db.QueryFirstOrDefault<SintezProduct>("getProduct", p, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<SintezProduct> GetAll()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.CONNECTIONSTRING].ConnectionString))
            {
                return db.Query<SintezProduct>("getProducts", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
