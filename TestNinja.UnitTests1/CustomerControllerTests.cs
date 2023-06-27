using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests1
{
    public class CustomerControllerTests
    {
        [Fact]
        public void GetCustomer_IdIsZero_ReturnsNotFound()
        {
            // Arrange
            var controller = new CustomerController();

            // Act
            var result = controller.GetCustomer(0);

            // Assert
            Assert.IsType<NotFound>(result);
        }
        [Fact]
        public void GetCustomer_IdIsNonZero_ReturnsOk()
        {
            // Arrange
            var controller = new CustomerController();

            // Act
            var result = controller.GetCustomer(1);

            // Assert
            Assert.IsType<Ok>(result);
        }
        [Fact]
        public void GetCustomer_ValidId_ReturnsOk()
        {
            // Arrange
            var controller = new CustomerController();

            // Act
            var result = controller.GetCustomer(10);

            // Assert
            Assert.IsType<Ok>(result);
        }

        [Fact]
        public void GetCustomer_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var controller = new CustomerController();

            // Act
            var result = controller.GetCustomer(0);

            // Assert
            Assert.IsType<NotFound>(result);
        }
    }
}
