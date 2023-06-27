using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;
namespace TestNinja.UnitTests1
{
    public class ReservationTests
    {
        [Fact]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue() {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });


            //Assert
            Assert.True(result);
        }
        [Fact]
        public void SameUserCancellingTheReservation_ReturnTrue()
        {
            var user = new User();
            var reservation = new Reservation { MadeBy = user};
            var result = reservation.CanBeCancelledBy(user);
            Assert.True(result);
        }
        [Fact]
        public void AnotherUserCancellingTheReservation_ReturnsTrue()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user };
            var anotherUser = new User();

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void CanBeCanceledBy_AnotherUserCancellingReservation_ReturnFalse()
        {
            var reservation = new Reservation { MadeBy = new User() };
            var result = reservation.CanBeCancelledBy(new User());
            Assert.False(result);
        }
        [Fact]
        public void SameUserCancellingTheReservation_ReturnsFalse()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.False(result);
        }
        [Fact]
        public void AnotherUserCancellingTheReservation_ReturnsFalse()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user };
            var anotherUser = new User();

            // Act
            var result = reservation.CanBeCancelledBy(anotherUser);

            // Assert
            Assert.False(result);
        }
    }
}