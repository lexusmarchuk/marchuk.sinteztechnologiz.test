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
    public class OrderRepository : IGenericRepository<SintezOrder>
    {
        public void Add(SintezOrder order)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.CONNECTIONSTRING].ConnectionString))
            {
                var p = new DynamicParameters();
                p.Add("@customerFullName", order.CustomerInfo.FullName);
                p.Add("@customerEmail", order.CustomerInfo.Email);
                p.Add("@shipToAddress", order.ShipTo.ShipToAddress);
                p.Add("@products", order.Products.AsTableValuedParameter("dbo.OrderProductTable", orderedColumnNames: new string[] { "ProductId", "Amount" }));

                db.Execute("addOrder", p, commandType: CommandType.StoredProcedure);
            }
        }

        public SintezOrder Get(int id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings[Constants.CONNECTIONSTRING].ConnectionString))
            {
                SintezOrder result = null;
                var p = new DynamicParameters();
                p.Add("@id", id);
                
                using (var order = db.QueryMultiple("getOrder", p, commandType: CommandType.StoredProcedure))
                {
                    var details = order.Read().Single();
                    var products = order.Read<SintezOrderProduct>().ToArray();

                    result = new SintezOrder
                    {
                        Id = id,
                        CustomerInfo = new SintezCustomer
                        {
                            FullName = details.CustomerFullName,
                            Email = details.CustomerEmail
                        },
                        ShipTo = new SintezOrderShipmentInfo
                        {
                            ShipToAddress = details.ShipToAddress
                        },
                        Products = products
                    };
                }

                return result;
            }
        }

        public IEnumerable<SintezOrder> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
