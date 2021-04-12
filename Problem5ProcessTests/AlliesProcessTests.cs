using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Problem1.Model;
using Problem1Process;
using System.Linq;

namespace Problem5ProcessTests
{
    [TestClass]
    public class AlliesProcessTests
    {
        [TestMethod]
        public void KingShan_Has_Secured_3_Allies_And_IstheRuler_CamelCaseInput()
        {
            //Arrange
            var process = new AlliesProcess();
            
            var requests = new AllianceRequest[] { new AllianceRequest() {  Country = "Air", SecretMessage = "oaaawaala"},
                                                   new AllianceRequest() {  Country = "Land", SecretMessage = "a1d22n333a4444p"},
                                                   new AllianceRequest() {  Country = "Ice", SecretMessage = "zmzmzmzaztzozh"}
            };

            //Act
            var result = process.EvaluateAlliance(requests,"space");

            //Assert
            Assert.AreEqual<string>(result.RulerName, "King Shan");
            Assert.AreEqual<int>(result.Allies.Count(), 3);
        }

        [TestMethod]
        public void KingShan_Has_Secured_3_Allies_And_IstheRuler_LowerCaseInput()
        {
            //Arrange
            var process = new AlliesProcess();

            var requests = new AllianceRequest[] { new AllianceRequest() {  Country = "air", SecretMessage = "oaaawaala"},
                                                   new AllianceRequest() {  Country = "land", SecretMessage = "a1d22n333a4444p"},
                                                   new AllianceRequest() {  Country = "ice", SecretMessage = "zmzmzmzaztzozh"}
            };

            //Act
            var result = process.EvaluateAlliance(requests, "space");

            //Assert
            Assert.AreEqual<string>(result.RulerName, "King Shan");
            Assert.AreEqual<int>(result.Allies.Count(), 3);
        }

        [TestMethod]
        public void KingShan_Has_Secured_3_Allies_And_IstheRuler_UpperCaseInput()
        {
            //Arrange
            var process = new AlliesProcess();
            var requests = new AllianceRequest[] { new AllianceRequest() {  Country = "AIR", SecretMessage = "oaaawaala"},
                                                   new AllianceRequest() {  Country = "LAND", SecretMessage = "a1d22n333a4444p"},
                                                   new AllianceRequest() {  Country = "ICE", SecretMessage = "zmzmzmzaztzozh"}
            };

            //Act
            var result = process.EvaluateAlliance(requests, "space");

            //Assert
            Assert.AreEqual<string>(result.RulerName, "King Shan");
            Assert.AreEqual<int>(result.Allies.Count(), 3);
        }

        [TestMethod]
        public void KingShan_Has_Secured_3_Allies_And_IstheRuler_SecretMessageUpperCase()
        {
            //Arrange
            var process = new AlliesProcess();

            var requests = new AllianceRequest[] { new AllianceRequest() {  Country = "AIR", SecretMessage = "oaaawaala".ToUpper()},
                                                   new AllianceRequest() {  Country = "LAND", SecretMessage = "a1d22n333a4444p".ToUpper()},
                                                   new AllianceRequest() {  Country = "ICE", SecretMessage = "zmzmzmzaztzozh".ToUpper()}
            };

            //Act
            var result = process.EvaluateAlliance(requests, "space");

            //Assert
            Assert.AreEqual<string>(result.RulerName, "King Shan");
            Assert.AreEqual<int>(result.Allies.Count(), 3);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Method_Invoked_With_InvalidCountry()
        {
            //Arrange
            var process = new AlliesProcess();

            var requests = new AllianceRequest[] { new AllianceRequest() {  Country = "INVALID_COUNTRY", SecretMessage = "oaaawaala".ToUpper()},
                                                   new AllianceRequest() {  Country = "LAND", SecretMessage = "a1d22n333a4444p".ToUpper()},
                                                   new AllianceRequest() {  Country = "ICE", SecretMessage = "zmzmzmzaztzozh".ToUpper()}
            };

            //Act
            var result = process.EvaluateAlliance(requests, "space");
        }

        [TestMethod]
        public void KingShan_CouldNotSecureAllies()
        {
            //Arrange
            var process = new AlliesProcess();

            var requests = new AllianceRequest[] { new AllianceRequest() {  Country = "AIR", SecretMessage = "osqsls".ToUpper()},
                                                   new AllianceRequest() {  Country = "LAND", SecretMessage = "a1d22n333a4444p".ToUpper()},
                                                   new AllianceRequest() {  Country = "ICE", SecretMessage = "zmzmzmzaztzozh".ToUpper()}
            };

            //Act
            var result = process.EvaluateAlliance(requests, "space");

            //Assert
            Assert.AreEqual<string>(result.RulerName, "None");
            Assert.AreEqual<int>(result.Allies.Count(), 0);
        }

        [TestMethod]
        public void KingShan_Has_Secured_3_Allies_And_IstheRuler_CheckUIFriendlyAllies()
        {
            //Arrange
            var process = new AlliesProcess();
            var requests = new AllianceRequest[] { new AllianceRequest() {  Country = "AIR", SecretMessage = "oaaawaala".ToUpper()},
                                                   new AllianceRequest() {  Country = "LAND", SecretMessage = "a1d22n333a4444p".ToUpper()},
                                                   new AllianceRequest() {  Country = "ICE", SecretMessage = "zmzmzmzaztzozh".ToUpper()}
            };

            //Act
            var result = process.EvaluateAlliance(requests, "space");

            //Assert
            Assert.AreEqual<string>(result.UIFriendlyListOfAllies, "Air, Land, Ice");
        }

        [TestMethod]
        public void KingShan_Sends_Same_Message_MultipleTimes()
        {
            //Arrange
            var process = new AlliesProcess();
            var requests = new AllianceRequest[] { new AllianceRequest() {  Country = "Air", SecretMessage = "oaaawaala"},
                                                   new AllianceRequest() {  Country = "Air", SecretMessage = "oaaawaala"},
                                                   new AllianceRequest() {  Country = "Air", SecretMessage = "oaaawaala"}
            };

            //Act
            var result = process.EvaluateAlliance(requests, "space");

            //Assert
            Assert.AreEqual<string>(result.RulerName, "None");
        }

        [TestMethod]
        public void KingShanHas_SentDifferentMessage_ToSameCountry()
        {
            //Arrange
            var process = new AlliesProcess();

            var requests = new AllianceRequest[] { new AllianceRequest() {  Country = "Air", SecretMessage = "oaaawaala"},
                                                   new AllianceRequest() {  Country = "Land", SecretMessage = "a1d22n333a4444p"},
                                                   new AllianceRequest() {  Country = "Ice", SecretMessage = "zmzmzmzaztzozh"},
                                                   new AllianceRequest() {  Country = "Air", SecretMessage = "oaaawaala"}
            };

            //Act
            var result = process.EvaluateAlliance(requests, "space");

            //Assert
            Assert.AreEqual<string>(result.RulerName, "King Shan");
            Assert.AreEqual<int>(result.Allies.Count(), 3);
        }
    }
}
