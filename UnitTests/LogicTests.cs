using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void BlankJokeShouldReturnBlank()
        {
            var logic = new Logic();

            var result = logic.HighlightTerms("", "Test");
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void ValidTermShouldBeReturnUpperCased()
        {
            var logic = new Logic();

            var result = logic.HighlightTerms("A joke with the word test in it", "Test");
            Assert.AreEqual("A joke with the word TEST in it", result);
        }

        [TestMethod]
        public void ValidTermShouldBeReturnUpperCasedPartialCases()
        {
            var logic = new Logic();

            var result = logic.HighlightTerms("A joke with the word testing in it", "Test");
            Assert.AreEqual("A joke with the word TESTing in it", result);
        }

    }
}
