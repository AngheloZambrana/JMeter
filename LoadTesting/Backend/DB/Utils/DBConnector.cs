using MySql.Data.MySqlClient;

namespace Backend.DB.Utils;

public static class DBConnector
{
    private static MySqlConnection _conn = new MySqlConnection("");
    
    private static string GetConnectionString()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("/webapp/dbsettings.json", optional: true)
            .Build();
        return config["DbSettings:ConnectionUrl"] ?? "";
    }
    
    public static MySqlConnection GetConnection()
    {
        var connection = new MySqlConnection(GetConnectionString());
        connection.Open();  
        return connection;
    }
}