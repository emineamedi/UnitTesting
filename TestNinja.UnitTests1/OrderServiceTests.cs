using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests1
{
    public class OrderServiceTests
    {
        [Fact]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            // Arrange
            var order = new Order();
            var storageMock = new Mock<IStorage>();
            var orderService = new OrderService(storageMock.Object);

            // Act
            var result = orderService.PlaceOrder(order);

            // Assert
            storageMock.Verify(s => s.Store(order), Times.Once);
        }
        [Fact]
        public void PlaceOrder_WhenCalled_ReturnsOrderId()
        {
            // Arrange
            var order = new Order();
            var expectedOrderId = 42; // Assuming this is the expected order ID
            var storageMock = new Mock<IStorage>();
            storageMock.Setup(s => s.Store(order)).Returns(expectedOrderId);
            var orderService = new OrderService(storageMock.Object);

            // Act
            var result = orderService.PlaceOrder(order);

            // Assert
            Assert.Equal(expectedOrderId, result);
        }
        /*
        [Fact]
        public void PlaceOrder_InvalidOrder_DoesNotStoreOrder()
        {
            // Arrange
            var invalidOrder = new Order(); // Create an invalid order
            var storageMock = new Mock<IStorage>();
            storageMock.Setup(s => s.Store(It.IsAny<Order>())).Returns(0); 
            var orderService = new OrderService(storageMock.Object);

            // Act
            var result = orderService.PlaceOrder(invalidOrder);

            // Assert
            storageMock.Verify(s => s.Store(It.IsAny<Order>()), Times.Never);
            Assert.Equal(0, result); 
        }
        */
        [Fact]
        public void PlaceOrder_ValidOrder_CallsStoreWithCorrectOrder()
        {
            // Arrange
            var order = new Order(); // Create a valid order
            var storageMock = new Mock<IStorage>();
            var orderService = new OrderService(storageMock.Object);

            // Act
            var result = orderService.PlaceOrder(order);

            // Assert
            storageMock.Verify(s => s.Store(order), Times.Once);
            
        }
        [Fact]
        public void PlaceOrder_ValidOrder_StoresOrderAndReturnsOrderId()
        {
            // Arrange
            var validOrder = new Order(); // Create a valid order
            var expectedOrderId = 42; // Set the expected order ID
            var storageMock = new Mock<IStorage>();
            storageMock.Setup(s => s.Store(validOrder)).Returns(expectedOrderId);
            var orderService = new OrderService(storageMock.Object);

            // Act
            var result = orderService.PlaceOrder(validOrder);

            // Assert
            storageMock.Verify(s => s.Store(validOrder), Times.Once);
            Assert.Equal(expectedOrderId, result);
        }
    }
}
