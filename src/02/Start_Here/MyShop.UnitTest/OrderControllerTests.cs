using System;
using Xunit;
using Moq;
using MyShop.Infrastructure.Repositories;
using MyShop.Domain.Models;
using MyShop.Web.Controllers;
using MyShop.Web.Models;

namespace MyShop.UnitTest
{
    public class OrderControllerTests
    {
        [Fact]
        public void CanCreateOrderWithCorrectModel()
        {
            var orderRepository = new Mock<IRepository<Order>>();
            var productRepository = new Mock<IRepository<Product>>();

            var orderController = new OrderController(orderRepository.Object, productRepository.Object);

            var createOrderModel = new CreateOrderModel
            {
                Customer = new CustomerModel
                {
                    Name = "Filip Ekberg",
                    ShippingAddress = "Address",
                    City = "Gothenburg",
                    PostalCode = "43317",
                    Country = "Sweden"
                },
                LineItems = new[]
                {
                    new LineItemModel{ ProductId = Guid.NewGuid(), Quantity = 2 },
                    new LineItemModel{ ProductId = Guid.NewGuid(), Quantity = 12 }
                }
            };

            orderController.Create(createOrderModel);

            orderRepository.Verify(repository => repository.Add(It.IsAny<Order>()), Times.AtMostOnce());
        }
    }
}
