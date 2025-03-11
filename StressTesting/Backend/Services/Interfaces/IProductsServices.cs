using Backend.DTOs.WithID;

namespace Backend.Services.Interfaces;

public interface IProductsServices
{
    public List<ProductsDTO> GetAllProducts();
}