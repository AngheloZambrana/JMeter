using AutoMapper;
using Backend.DB.DAOs.Abstract.SingleDAO;
using Backend.DTOs.WithID;
using Backend.Entities;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class ProductsServices : IProductsServices
{
    private readonly IProductsDAO _productsDAO;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductsServices> _logger;

    public ProductsServices(IProductsDAO productsDAO, IMapper mapper, ILogger<ProductsServices> logger)
    {
        _productsDAO = productsDAO;
        _mapper = mapper;
        _logger = logger;
    }
    
    public List<ProductsDTO> GetAllProducts()
    {
        return _productsDAO.ReadAll().Select(_mapper.Map<ProductsDTO>).ToList();
    }
}