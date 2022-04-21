using WebAppMvc.Models.Context;
using WebAppMvc.Models.Entities;

namespace WebAppMvc.Models.Services;

public class ProductService : IProductService
{
    private readonly DatabaseContext _dbContext;

    public ProductService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Product product)
    {
        _dbContext.Add(product);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
        _dbContext.Remove(product);
        _dbContext.SaveChanges();
    }

    public Product Get(int id)
    {
        return _dbContext.Products.FirstOrDefault(p => p.Id == id);
     }

    public IEnumerable<Product> GetAll()
    {
        return _dbContext.Products.ToList();
    }
}

