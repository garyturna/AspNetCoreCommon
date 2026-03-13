namespace DataLibrary.Db
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T>(string storedProcedure, object parameters, string connectionStringName);
        Task<int> SaveData(string storedProcedure, object parameters, string connectionStringName);
    }
}