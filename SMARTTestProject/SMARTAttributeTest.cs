using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Guardian.SMART;
using Guardian;

namespace SMARTTestProject
{
    [TestClass]
    public class SMARTAttributeTest
    {
        [TestMethod]
        public void TestSMARTAttributeNameInitialization_IsCorrect()
        {
            var smart = new SMARTAttribute(194, 100, 100, 100, 100);
            var expected = "Temperature";

            Assert.AreEqual(smart.Name, expected, "Attribute name is not the same as expected");
        }

        [TestMethod]
        public void TestSMARTAttributeNameInitialization_IsNotUnknownAttribute()
        {
            var smart = new SMARTAttribute(190, 100, 100, 50, 30);
            var expected = "Unknown attribute";

            Assert.AreNotEqual(expected, smart.Name, "Attribute name must be different than expected!");
        }
        
        [TestMethod]
        [ExpectedException(typeof(SMARTAttributeException))]
        public void TestSMARTAttributeRawValue_OutOfRange()
        {
            var smart = new SMARTAttribute(13, 100, 100, -341, 400);
        }

        [TestMethod]
        [ExpectedException(typeof(SMARTAttributeException))]
        public void TestSMARTAttributeThreasholdValue_OutOfRange()
        {
            var smart = new SMARTAttribute(13, 100, 100, 100, -32);
        }
        
        [TestMethod]
        public void TestSMARTAttributeIsCritical_Critical()
        {
            var smart = new SMARTAttribute(5, 100, 100, 100, 100);
            var expected = true;

            Assert.AreEqual(smart.IsCritical, expected, "SMART Attribute must be marked as critical");
        }

        [TestMethod]
        [ExpectedException(typeof(SMARTAttributeException))]
        public void TestSMARTAttribute_IDOutOfRange()
        {
            var smart = new SMARTAttribute(255, 255, 255, 100, 255);
        }

        [TestMethod]
        [ExpectedException(typeof(SMARTAttributeException))]
        public void TestSMARTAttribute_IdOutOfRangeNegativeValue()
        {
            var smart = new SMARTAttribute(-1, 29, 100, 30, 59);
        }
        [TestMethod]
        public void TestSMARTAttribute_IsNotCritical()
        {
            var smart = new SMARTAttribute(6, 100, 100, 100, 100);
            var expected = false;

            Assert.AreEqual(smart.IsCritical, expected, "SMART Attribute must not be critical");
        }
        [TestMethod]
        public void TestSMARTAttributeNameInitialization_IsUnknownAttribute()
        {
            var smart = new SMARTAttribute(14, 100, 100, 100, 100);
            var expected = "Unknown attribute";

            Assert.AreEqual(smart.Name, expected, "Attribute name must be set to Unknown attribute");
        }

        [TestMethod]
        public void TestSMARTIdInitialization_IsOk()
        {
            var smart = new SMARTAttribute(13, 100, 100, 100, 100);
            var expected = 13;

            Assert.AreEqual(smart.ID, expected, "Attribute ID doesn't initialize correctly!");
        }

        [TestMethod]
        public void TestSMARTAttributeValueInitialization_IsOk()
        {
            var smart = new SMARTAttribute(194, 100, 100, 100, 100);
            var expected = 100;

            Assert.AreEqual(smart.Value, expected, "Attribute value doesn't initialize correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(SMARTAttributeException))]
        public void TestSMARTAttributeValueOutOfRange_ThrowingException()
        {
            var smart = new SMARTAttribute(13, -1, 100, 0, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(SMARTAttributeException))]
        public void TestSMARTAttributeWorstOutOfRange_ThrowException()
        {
            var smart = new SMARTAttribute(13, 1, -1, 100, 100);
        }

        [TestMethod]
        public void TestSMARTAttributeWorstValue_IsCorrect()
        {
            var smart = new SMARTAttribute(13, 100, 100, 100, 100);
            var expected = 100;

            Assert.AreEqual(smart.Worst, expected, "SMART Attribute value is not the same as expected!");
        }

        public void TestSMARTAttributeWorstValue_IsNotCorrect()
        {
            var smart = new SMARTAttribute(13, 100, 100, 100, 100);
            var expected = 90;

            Assert.AreNotEqual(smart.Worst, expected, "SMART Attribute worst value is wrong!");
        }
    }
}
