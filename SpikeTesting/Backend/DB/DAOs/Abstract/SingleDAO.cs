using System.Text;
using System.Data;
using Backend.DB.Utils;
using MySql.Data.MySqlClient;

namespace Backend.DB.DAOs.Abstract;

public abstract class SingleDAO<T> : IDAO<T>
{
    private protected string _tableName = string.Empty;

    private protected StringBuilder? _sb;

    private protected List<T>? _entitiesList;

    private protected MySqlDataReader? _mySqlReader;
    
    private protected T? _entity;
    
    private MySqlCommand? _dbCommand; 
    
    public List<T> ReadAll()
    {
        return  ExecuteReadAllOperation();
    }
    

    private protected List<T> ExecuteReadAllOperation()
    {
        using (var connection = DBConnector.GetConnection())  
        {
            using (var command = new MySqlCommand(_tableName, connection))
            {
                command.CommandType = CommandType.TableDirect;
                using (_mySqlReader = command.ExecuteReader()) 
                {
                    return MapReaderToEntitiesList();
                }
            }
        }
    }

    private protected abstract List<T> MapReaderToEntitiesList();
}
