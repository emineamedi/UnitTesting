using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests1
{
    public class PhoneNumberTests
    {
        [Fact]
        public void Parse_ValidPhoneNumber_ReturnsPhoneNumberObject()
        {
            // Arrange
            string phoneNumberString = "1234567890";

            // Act
            var phoneNumber = PhoneNumber.Parse(phoneNumberString);

            // Assert
            Assert.NotNull(phoneNumber);
            Assert.Equal("123", phoneNumber.Area);
            Assert.Equal("456", phoneNumber.Major);
            Assert.Equal("7890", phoneNumber.Minor);
        }
        [Fact]
        public void Parse_NullOrEmptyPhoneNumber_ThrowsArgumentException()
        {
            // Arrange
            string phoneNumberString = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => PhoneNumber.Parse(phoneNumberString));
        }

        [Fact]
        public void Parse_InvalidPhoneNumberLength_ThrowsArgumentException()
        {
            // Arrange
            string phoneNumberString = "123456";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => PhoneNumber.Parse(phoneNumberString));
        }
        [Fact]
        public void ToString_FormatsPhoneNumberCorrectly()
        {
            // Arrange
            string phoneNumberString = "1234567890";
            var phoneNumber = PhoneNumber.Parse(phoneNumberString);

            // Act
            string formattedNumber = phoneNumber.ToString();

            // Assert
            Assert.Equal("(123)456-7890", formattedNumber);
        }
        [Fact]
        public void Parse_InvalidPhoneNumberCharacters_ThrowsArgumentException()
        {
            // Arrange
            string phoneNumberString = "12A34567890";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => PhoneNumber.Parse(phoneNumberString));
        }
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void Parse_NullOrEmptyPhoneNumber_ThrowsArgumentException1(string phoneNumberString)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => PhoneNumber.Parse(phoneNumberString));
        }
        [Theory]
        [InlineData("123456")]
        [InlineData("12345678901")]
        public void Parse_InvalidPhoneNumberLength_ThrowsArgumentException2(string phoneNumberString)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => PhoneNumber.Parse(phoneNumberString));
        }
    }
}
