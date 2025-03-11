using System.Text;
using Backend.DB.DAOs.Abstract;
using Backend.DB.DAOs.Abstract.SingleDAO;
using Backend.Entities;

namespace Backend.DB.DAOs.Concrete;

public class ProductsDAO : SingleDAO<Products>, IProductsDAO
{
    public ProductsDAO()
    {
        _tableName = "Products";
    }
    
    private protected override List<Products> MapReaderToEntitiesList()
    {
        _entitiesList = new List<Products>();
        try
        {
            while (_mySqlReader!.Read())
            {
                _entity = new Products()
                {
                    Id = _mySqlReader!.GetInt32(0),
                    Name = _mySqlReader!.GetString(1),
                    Price = _mySqlReader!.GetDecimal(2)
                };
                _entitiesList.Add(_entity);
            }
        }
        finally
        {
            _mySqlReader?.Close(); 
        }
        return _entitiesList;
    }
    
}