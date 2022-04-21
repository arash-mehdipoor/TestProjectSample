using WebAppMvc.Models.Entities;

namespace WebAppMvc.Models.MoqData
{
    public class MoqData
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product(){ Id = 1, Name ="P1",Description ="P1 Description",Price =200},
                new Product(){ Id = 2, Name ="P2",Description ="P2 Description",Price =300}
            };
            return products;
        }
    }
}
