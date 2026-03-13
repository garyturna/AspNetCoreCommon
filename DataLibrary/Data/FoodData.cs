using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Data
{
    public class FoodData : IFoodData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public FoodData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<FoodModel>> GetFood()
        {
            return _dataAccess.LoadData<FoodModel>("dbo.spFood_GetAll",
                                                    new { },
                                                    _connectionString.SqlConnectionString);
        }
    }
}
