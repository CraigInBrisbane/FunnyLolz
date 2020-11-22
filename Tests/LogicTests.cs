using Business;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class LogicTests
    {

        private Logic _logic;

        [SetUp]
        public void Setuo()
        {
            _logic = new Logic();
        }

        [Test]
        public void BlankTestShouldReturnBlankString()
        {
            var result = _logic.HighlightTerms("", "Test");

            // Assert
            Assert.Equals("", result);
        }
    }
}
