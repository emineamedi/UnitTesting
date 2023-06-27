using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests1
{
    public class MathTests
    {
        private readonly Math _math;

        public MathTests()
        {
            _math = new Math();
        }

        [Fact]
        public void Add_WhenCalled_ReturnsTheSumOfArguments()
        {
            // Arrange
            int a = 5;
            int b = 10;

            // Act
            int result = _math.Add(a, b);

            // Assert
            Assert.Equal(15, result);
        }
        [Fact]
        public void Max_FirstArgumentIsGreater_ReturnsFirstArgument()
        {
            // Arrange
            int a = 10;
            int b = 5;

            // Act
            int result = _math.Max(a, b);

            // Assert
            Assert.Equal(a, result);
        }
        [Fact]
        public void Max_SecondArgumentIsGreater_ReturnsSecondArgument()
        {
            // Arrange
            int a = 5;
            int b = 10;

            // Act
            int result = _math.Max(a, b);

            // Assert
            Assert.Equal(b, result);
        }
        [Theory]
        [InlineData(0, new int[0])]  // No odd numbers
        [InlineData(5, new[] { 1, 3, 5 })]  // Odd numbers from 1 to 5
        [InlineData(10, new[] { 1, 3, 5, 7, 9 })]  // Odd numbers from 1 to 10
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnsOddNumbersUpToLimit(int limit, int[] expectedResult)
        {
            // Act
            var result = _math.GetOddNumbers(limit);

            // Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void Add_MaxIntValues_ReturnsCorrectResult()
        {
            // Arrange
            int a = int.MaxValue;
            int b = int.MaxValue;

            // Act
            int result = _math.Add(a, b);

            // Assert
            Assert.Equal(-2, result);
        }
        [Fact]
        public void Add_NegativeNumbers_ReturnsCorrectResult()
        {
            // Arrange
            int a = -5;
            int b = -10;

            // Act
            int result = _math.Add(a, b);

            // Assert
            Assert.Equal(-15, result);
        }
        [Fact]
        public void Add_ZeroAsInput_ReturnsZero()
        {
            // Arrange
            int a = 0;
            int b = 0;

            // Act
            int result = _math.Add(a, b);

            // Assert
            Assert.Equal(0, result);
        }
        [Fact]
        public void GetOddNumbers_LimitIsNegative_ReturnsEmptyList()
        {
            // Arrange
            int limit = -5;

            // Act
            var result = _math.GetOddNumbers(limit);

            // Assert
            Assert.Empty(result);
        }
        [Fact]
        public void GetOddNumbers_LimitIsZero_ReturnsEmptyList()
        {
            // Arrange
            int limit = 0;

            // Act
            var result = _math.GetOddNumbers(limit);

            // Assert
            Assert.Empty(result);
        }
        [Fact]
        public void GetOddNumbers_LargeLimit_ReturnsExpectedResult()
        {
            // Arrange
            int limit = 100000;

            // Act
            var result = _math.GetOddNumbers(limit);

            // Assert
            Assert.Equal(50000, result.Count());
            Assert.Equal(1, result.First());
            Assert.Equal(99999, result.Last());
        }

        [Fact]
        public void GetOddNumbers_ReturnsOnlyOddNumbers()
        {
            // Arrange
            int limit = 10;

            // Act
            var result = _math.GetOddNumbers(limit);

            // Assert
            Assert.All(result, number => Assert.True(number % 2 != 0));
        }

        [Fact]
        public void Add_HandlesOverflowCorrectly()
        {
            // Arrange
            int a = int.MaxValue;
            int b = 1;

            // Act
            int result = _math.Add(a, b);

            // Assert
            Assert.Equal(int.MinValue, result);
        }

        [Fact]
        public void Max_BothArgumentsAreEqual_ReturnsEitherArgument()
        {
            // Arrange
            int a = 10;
            int b = 10;

            // Act
            int result = _math.Max(a, b);

            // Assert
            Assert.Equal(a, result);
        }

        [Fact]
        public void Add_PerformanceTest()
        {
            // Arrange
            int a = 5;
            int b = 10;
            int iterations = 1000000;

            // Act
            for (int i = 0; i < iterations; i++)
            {
                _math.Add(a, b);
            }

            // No assertion, performance test only
        }
    }
}
