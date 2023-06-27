using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests1
{
    public class DeterminePointsCalculator
    {
        [Fact]
        public void CalculateDemeritPoints_SpeedBelowLimit_ReturnsZeroDemeritPoints()
        {
            // Arrange
            var calculator = new DemeritPointsCalculator();
            var speed = 60;

            // Act
            var result = calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateDemeritPoints_SpeedAboveLimit_ReturnsCorrectDemeritPoints()
        {
            // Arrange
            var calculator = new DemeritPointsCalculator();
            var speed = 75;

            // Act
            var result = calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void CalculateDemeritPoints_NegativeSpeed_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var calculator = new DemeritPointsCalculator();
            var speed = -10;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateDemeritPoints(speed));
        }

        [Fact]
        public void CalculateDemeritPoints_SpeedExceedsMaxSpeed_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var calculator = new DemeritPointsCalculator();
            var speed = 350;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateDemeritPoints(speed));
        }

        [Fact]
        public void CalculateDemeritPoints_SpeedEqualsSpeedLimit_ReturnsZeroDemeritPoints()
        {
            // Arrange
            var calculator = new DemeritPointsCalculator();
            var speed = 65;

            // Act
            var result = calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateDemeritPoints_SpeedSlightlyAboveLimit_ReturnsCorrectDemeritPoints()
        {
            // Arrange
            var calculator = new DemeritPointsCalculator();
            var speed = 70;

            // Act
            var result = calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void CalculateDemeritPoints_SpeedSignificantlyAboveLimit_ReturnsCorrectDemeritPoints()
        {
            // Arrange
            var calculator = new DemeritPointsCalculator();
            var speed = 100;

            // Act
            var result = calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void CalculateDemeritPoints_SpeedEqualsMaxSpeed_ReturnsCorrectDemeritPoints()
        {
            // Arrange
            var calculator = new DemeritPointsCalculator();
            var speed = 300;

            // Act
            var result = calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.Equal(47, result);
        }

        [Fact]
        public void CalculateDemeritPoints_SpeedExceedsMaxSpeed_ReturnsCorrectDemeritPoints()
        {
            // Arrange
            var calculator = new DemeritPointsCalculator();
            var speed = 350;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateDemeritPoints(speed));
        }
    }
}
