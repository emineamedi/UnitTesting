using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests1
{
    public class FizzBuzzTests
    {
        [Fact]
        public void GetOutput_DivisibleBy3And5_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.Equal("FizzBuzz", result);
        }
        [Fact]
        public void GetOutput_DivisibleBy3_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(9);
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void GetOutput_DivisibleBy5_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(10);
            Assert.Equal("Buzz", result);
        }
        [Fact]
        public void GetOutput_NotDivisibleBy3Or5_ReturnsNumberAsString()
        {
            var result = FizzBuzz.GetOutput(7);
            Assert.Equal("7", result);
        }
        [Fact]
        public void GetOutput_InputIsZero_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(0);
            Assert.Equal("FizzBuzz", result);
        }

        [Fact]
        public void GetOutput_InputIsNegativeNumberDivisibleBy3_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(-9);
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void GetOutput_InputIsNegativeNumberDivisibleBy5_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(-10);
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void GetOutput_LargeNumberDivisibleBy3And5_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(1500);
            Assert.Equal("FizzBuzz", result);
        }
}
}
