using Backend.DTOs.WithID;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductsServices _productsService;

    public ProductsController(IProductsServices productsService)
    {
        _productsService = productsService;
    }

    [HttpGet]
    public ActionResult<List<ProductsDTO>> GetAllProducts()
    {
        var result = _productsService.GetAllProducts();
        return Ok(result);
    }
}