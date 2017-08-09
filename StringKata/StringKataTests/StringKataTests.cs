using System;
using StringKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringKataTests
{
    [TestClass]
    public class StringKataTests
    {
        [TestMethod]
        public void EmptyStringReturnsZero()
        {
            "".ShouldBeEqualTo(0);
        }

        [TestMethod]
        public void AddOneNumber()
        {
            "1".ShouldBeEqualTo(1);
        }

        [TestMethod]
        public void AddTwoNumbers()
        {
            "1,2".ShouldBeEqualTo(3);
        }

        [TestMethod]
        public void AddMultipleNumbers()
        {
            "1,2,3".ShouldBeEqualTo(6);
        }

        [TestMethod]
        public void NewLineCanBeDelimeter()
        {
            "1\n2,3".ShouldBeEqualTo(6);
        }

        [TestMethod]
        public void UserCanDefineOwnDelimeter()
        {
            "//;\n1;2".ShouldBeEqualTo(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeNumberThrowsException()
        {
            var sut = new StringCalculator();

            sut.Add("-1,2");
        }

        [TestMethod]
        public void NegativeNumberExceptionListsAllNegatives()
        {
            var sut = new StringCalculator();
            var message = "";

            try
            {
                sut.Add("-1,2,-3");
            }
            catch (ArgumentException e)
            {
                message = e.Message;
            }

            Assert.AreEqual("Invalid numbers: -1,-3", message);
        }
    }

    public static class StringKataTestsHelper
    {
        public static void ShouldBeEqualTo(this string input, int expected)
        {
            var sut = new StringCalculator();
            Assert.AreEqual(expected, sut.Add(input));
        }
    }
}
