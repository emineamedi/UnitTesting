using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests1
{
    public class ErrorLoggerTests
    {
        [Fact]
        public void Log_WhenErrorIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var logger = new ErrorLogger();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => logger.Log(null));
        }
        [Fact]
        public void Log_WhenErrorIsEmpty_ThrowsArgumentNullException()
        {
            // Arrange
            var logger = new ErrorLogger();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => logger.Log(""));
        }
        [Fact]
        public void Log_WhenErrorIsWhitespace_ThrowsArgumentNullException()
        {
            // Arrange
            var logger = new ErrorLogger();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => logger.Log("   "));
        }
        [Fact]
        public void Log_WhenValidErrorString_LastErrorIsSet()
        {
            // Arrange
            var logger = new ErrorLogger();
            var error = "Sample error message";

            // Act
            logger.Log(error);

            // Assert
            Assert.Equal(error, logger.LastError);
        }
        [Fact]
        public void Log_WhenValidErrorString_ErrorLoggedEventIsRaised()
        {
            // Arrange
            var logger = new ErrorLogger();
            var error = "Sample error message";
            var eventRaised = false;
            logger.ErrorLogged += (sender, args) => eventRaised = true;

            // Act
            logger.Log(error);

            // Assert
            Assert.True(eventRaised);
        }
    }
}
