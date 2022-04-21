using WebAppMvc.Models.Entities;

namespace WebAppMvc.Models.Services;
public interface IProductService
{
    void Add(Product product);
    void Delete(int id);
    Product Get(int id);
    IEnumerable<Product> GetAll();
}

