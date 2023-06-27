using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests1
{
    public class DateHelperTests
    {
        [Fact]
        public void FirstOfNextMonth_RegularDate_ReturnsFirstDayOfNextMonth()
        {
            // Arrange
            var date = new DateTime(2023, 1, 15);

            // Act
            var result = DateHelper.FirstOfNextMonth(date);

            // Assert
            Assert.Equal(new DateTime(2023, 2, 1), result);
        }

        [Fact]
        public void FirstOfNextMonth_LastDayOfYear_ReturnsFirstDayOfNextYear()
        {
            // Arrange
            var date = new DateTime(2022, 12, 31);

            // Act
            var result = DateHelper.FirstOfNextMonth(date);

            // Assert
            Assert.Equal(new DateTime(2023, 1, 1), result);
        }

        [Fact]
        public void FirstOfNextMonth_LastDayOfMonth_ReturnsFirstDayOfNextMonth()
        {
            // Arrange
            var date = new DateTime(2023, 3, 31);

            // Act
            var result = DateHelper.FirstOfNextMonth(date);

            // Assert
            Assert.Equal(new DateTime(2023, 4, 1), result);
        }

        [Fact]
        public void FirstOfNextMonth_LeapYearDate_ReturnsFirstDayOfNextMonth()
        {
            // Arrange
            var date = new DateTime(2024, 2, 29);

            // Act
            var result = DateHelper.FirstOfNextMonth(date);

            // Assert
            Assert.Equal(new DateTime(2024, 3, 1), result);
        }
    }
}
