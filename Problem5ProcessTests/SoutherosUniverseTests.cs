using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problem1.Process;
using System;
using System.Linq;

namespace Problem5ProcessTests
{
    [TestClass]
    public class SoutherosUniverseTests
    {
        [TestMethod]
        public void WhenAllyNameIsInCamelCaseThenIgnoreCase()
        {
            //Arrange
            var process = new SoutherosUniverse();

            //Act
            var got = process.Invasion("space", new string[]
            {
                "Air,oaaawaala",
                "Land,a1d22n333a4444p",
                "Ice,zmzmzmzaztzozh"
            });

            //Assert
            Assert.IsTrue(got.Any(x => string.Equals(x, "Air", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(got.Any(x => string.Equals(x, "Land", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(got.Any(x => string.Equals(x, "Ice", StringComparison.OrdinalIgnoreCase)));
        }

        [TestMethod]
        public void WhenAllyNameIsInLowerCaseThenIgnoreCase()
        {
            //Arrange
            var process = new SoutherosUniverse();

            //Act
            var got = process.Invasion("space", new string[]
            {
                "air,oaaawaala",
                "land,a1d22n333a4444p",
                "ice,zmzmzmzaztzozh"
            });

            //Assert
            Assert.IsTrue(got.Any(x => string.Equals(x, "Air", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(got.Any(x => string.Equals(x, "Land", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(got.Any(x => string.Equals(x, "Ice", StringComparison.OrdinalIgnoreCase)));
        }

        [TestMethod]
        public void WhenAllyNameIsInUpperCaseThenIgnoreCase()
        {
            //Arrange
            var process = new SoutherosUniverse();

            //Act
            var got = process.Invasion("space", new string[]
            {
                "AIR,oaaawaala",
                "LAND,a1d22n333a4444p",
                "ICE,zmzmzmzaztzozh"
            });

            //Assert
            Assert.IsTrue(got.Any(x => string.Equals(x, "Air", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(got.Any(x => string.Equals(x, "Land", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(got.Any(x => string.Equals(x, "Ice", StringComparison.OrdinalIgnoreCase)));
        }

        [TestMethod]
        public void WhenSecretMessageIsInUpperCaseThenIgnoreCase()
        {
            //Arrange
            var process = new SoutherosUniverse();

            //Act
            var got = process.Invasion("space", new string[]
            {
                "Air,oaaawaala".ToUpper(),
                "Land,a1d22n333a4444p".ToUpper(),
                "Ice,zmzmzmzaztzozh".ToUpper()
            });

            //Assert
            Assert.IsTrue(got.Any(x => string.Equals(x, "Air", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(got.Any(x => string.Equals(x, "Land", StringComparison.OrdinalIgnoreCase)));
            Assert.IsTrue(got.Any(x => string.Equals(x, "Ice", StringComparison.OrdinalIgnoreCase)));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WhenInvalidKingdomAsAlliesThenThrowException()
        {
            //Arrange
            var process = new SoutherosUniverse();

            //Act
            var got = process.Invasion("space", new string[]
            {
                "NOT_A_KINGDOM,oaaawaala",
                "Land,a1d22n333a4444p",
                "Ice,zmzmzmzaztzozh"
            });
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WhenInvalidInvadorThenThrowException()
        {
            //Arrange
            var process = new SoutherosUniverse();

            //Act
            var got = process.Invasion("INVALID_INVADOR", new string[]
            {
                "NOT_A_KINGDOM,oaaawaala",
                "Land,a1d22n333a4444p",
                "Ice,zmzmzmzaztzozh"
            });
        }

        [TestMethod]
        public void WhenWrongSecretMessageThenNoAllies()
        {
            //Arrange
            var process = new SoutherosUniverse();

            //Act
            var got = process.Invasion("space", new string[]
            {
                "Air,osqsls",
                "Land,a1d22n333a4444p",
                "Ice,zmzmzmzaztzozh"
            });

            //Assert
            Assert.IsTrue(got.Length == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WhenSameAllyIsTriedMultipleTimesThenThrowException()
        {

            //Arrange
            var process = new SoutherosUniverse();

            //Act
            var got = process.Invasion("space", new string[]
            {
                "Air,oaaawaala".ToUpper(),
                "Air,oaaawaala".ToUpper(),
                "Air,oaaawaala".ToUpper()
            });

            //Assert
            Assert.IsTrue(got.Length == 0);
        }
    }
}
