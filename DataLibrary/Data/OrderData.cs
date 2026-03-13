using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataLibrary.Data
{
    public class OrderData : IOrderData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public OrderData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<int> CreateOrder(OrderModel order)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@OrderName", order.OrderName);
            p.Add("@OrderDate", order.OrderDate);
            p.Add("@FoodId", order.FoodId);
            p.Add("@Quantity", order.Quantity);
            p.Add("@Total", order.Total);
            p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spOrders_Insert", p, _connectionString.SqlConnectionString);

            return p.Get<int>("@Id");
        }

        public Task<int> UpdateOrderName(int orderId, string orderName)
        {
            return _dataAccess.SaveData("dbo.spOrders_UpdateOrderName",
                                        new { Id = orderId, OrderName = orderName },
                                        _connectionString.SqlConnectionString);
        }

        public Task<int> DeleteOrder(int orderId)
        {
            return _dataAccess.SaveData("dbo.spOrders_Delete",
                                        new { Id = orderId },
                                        _connectionString.SqlConnectionString);
        }

        public async Task<OrderModel> GetOrderById(int orderId)
        {
            var recs = await _dataAccess.LoadData<OrderModel>("dbo.spOrders_GetById",
                                                        new { Id = orderId },
                                                        _connectionString.SqlConnectionString);
            return recs.FirstOrDefault();
        }

    }
}
