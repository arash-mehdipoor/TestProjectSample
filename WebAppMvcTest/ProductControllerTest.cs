using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using WebAppMvc.Controllers;
using WebAppMvc.Models.Entities;
using WebAppMvc.Models.MoqData;
using WebAppMvc.Models.Services;
using Xunit;

namespace WebAppMvcTest
{
    public class ProductControllerTest
    {
        [Fact]
        public void Index_Test()
        {
            // Arrange
            MoqData moqData = new MoqData();


            var moq = new Mock<IProductService>();

            moq.Setup(p => p.GetAll()).Returns(moqData.GetProducts());

            ProductController controller = new ProductController(moq.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);

            var viewResult = result as ViewResult;

            Assert.IsAssignableFrom<List<Product>>(viewResult.ViewData.Model);
        }

        [Theory]
        [InlineData(1, -1)]
        public void Details_Test(int validId, int inValidId)
        {
            //Arrange
            MoqData moqData = new MoqData();

            var moq = new Mock<IProductService>();
            moq.Setup(p => p.Get(validId)).Returns(moqData.GetProducts().Find(x => x.Id == validId));
            ProductController controller = new ProductController(moq.Object);

            // Act
            var result = controller.Details(validId);
            //Assert 
            Assert.IsType<ViewResult>(result);
            var vresult = result as ViewResult;
            Assert.IsAssignableFrom<Product>(vresult.ViewData.Model);



            //Arrange
            moq.Setup(p => p.Get(inValidId)).Returns(moqData.GetProducts().Find(x => x.Id == inValidId));

            // Act
            var invalidResult = controller.Details(inValidId);

            //Assert
            Assert.IsType<NotFoundResult>(invalidResult); 
        }
    }
}