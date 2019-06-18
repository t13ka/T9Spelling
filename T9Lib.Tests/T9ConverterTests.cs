namespace T9Lib.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using T9Common;

    [TestClass]
    public class T9ConverterTests
    {
        private IT9Converter _t9Converter;

        [TestInitialize]
        public void Setup()
        {
            _t9Converter = new T9Converter();
        }

        [TestMethod]
        [DataRow("0", " ")]
        [DataRow("44 444", "hi")]
        [DataRow("999337777", "yes")]
        [DataRow("333666 6660 022 2777", "foo  bar")]
        [DataRow("4433555 555666096667775553", "hello world")]
        [DataRow("8899993332226622", "uzfcnb")]
        public void ConvertString_ShouldReturn_ExpectedResult(string expected, string input)
        {
            Assert.AreEqual(expected, _t9Converter.ConvertString(input));
        }
    }
}