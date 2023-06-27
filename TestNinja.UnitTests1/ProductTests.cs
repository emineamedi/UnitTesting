using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests1
{
    public class ProductTests
    {
        [Fact]
        public void GetPrice_CustomerIsGold_ReturnsDiscountedPrice()
        {
            // Arrange
            var product = new Product { ListPrice = 100 };
            var customer = new Customer { IsGold = true };

            // Act
            var price = product.GetPrice(customer);

            // Assert
            Assert.Equal(70, price);
        }
        [Fact]
        public void GetPrice_CustomerIsNotGold_ReturnsOriginalPrice()
        {
            // Arrange
            var product = new Product { ListPrice = 100 };
            var customer = new Customer { IsGold = false };

            // Act
            var price = product.GetPrice(customer);

            // Assert
            Assert.Equal(100, price);
        }
        [Fact]
        public void GetPrice_NonGoldCustomer_ReturnsListPrice()
        {
            // Arrange
            var product = new Product { ListPrice = 100 };
            var customer = new Customer { IsGold = false };

            // Act
            var price = product.GetPrice(customer);

            // Assert
            Assert.Equal(100, price);
        }

        [Fact]
        public void GetPrice_GoldCustomer_ReturnsDiscountedPrice()
        {
            // Arrange
            var product = new Product { ListPrice = 100 };
            var customer = new Customer { IsGold = true };

            // Act
            var price = product.GetPrice(customer);

            // Assert
            Assert.Equal(70, price);
        }

        [Fact]
        public void GetPrice_ZeroListPrice_ReturnsZero()
        {
            // Arrange
            var product = new Product { ListPrice = 0 };
            var customer = new Customer { IsGold = false };

            // Act
            var price = product.GetPrice(customer);

            // Assert
            Assert.Equal(0, price);
        }

        [Fact]
        public void GetPrice_NegativeListPrice_ReturnsNegativePrice()
        {
            // Arrange
            var product = new Product { ListPrice = -100 };
            var customer = new Customer { IsGold = false };

            // Act
            var price = product.GetPrice(customer);

            // Assert
            Assert.Equal(-100, price);
        }
    }
}
