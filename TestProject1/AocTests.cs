using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

public enum Direction
{
    forward,
    down,
    up
}

namespace TestProject1
{
    public class AocTests
    {
        private readonly ITestOutputHelper _output;
        
        public AocTests(ITestOutputHelper output)
        {
            _output = output;
        }
        
        [Fact]
        public void Day2_Part1()
        {
            var text = System.IO.File.ReadAllText(@"C:\Development\adventofcode2021\TestProject1\TestProject1\input.txt");
            var inputs = text.Split(("\n"));
            var totalDepth = 0;
            var totalDistance = 0;
            
            foreach (var input in inputs)
            {
                var directionAndLength = input.Split(" ");
                Enum.TryParse<Direction>(directionAndLength.First(), out var direction );
                var length = int.Parse(directionAndLength[1]);

                switch (direction)
                {
                    case Direction.forward:
                        totalDistance += length;
                        break;
                    case Direction.down:
                        totalDepth += length;
                        break;
                    case Direction.up:
                        totalDepth -= length;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Assert.NotEqual(0, totalDepth);
            Assert.NotEqual(0, totalDistance);
            _output.WriteLine("Final position is {0}", totalDepth * totalDistance);
        }
        
        [Fact]
        public void Day2_Part2()
        {
            var text = System.IO.File.ReadAllText(@"C:\Development\adventofcode2021\TestProject1\TestProject1\input.txt");
            var inputs = text.Split(("\n"));
            var totalDepth = 0;
            var totalDistance = 0;
            var aim = 0;
            
            foreach (var input in inputs)
            {
                var directionAndLength = input.Split(" ");
                Enum.TryParse<Direction>(directionAndLength.First(), out var direction );
                var length = int.Parse(directionAndLength[1]);

                switch (direction)
                {
                    case Direction.forward:
                        totalDistance += length;
                        totalDepth += aim * length;
                        break;
                    case Direction.down:
                        aim += length;
                        break;
                    case Direction.up:
                        aim -= length;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Assert.NotEqual(0, totalDepth);
            Assert.NotEqual(0, totalDistance);
            Assert.NotEqual(0, aim);
            _output.WriteLine("Final position is {0}", totalDepth * totalDistance);
        }
    }
}