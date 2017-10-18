using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace T9Lib.Tests
{
    using T9Common;

    [TestClass]
    public class T9ConvertionTests
    {
        private readonly IT9Converter _t9Converter = new T9Converter();

        [TestMethod]
        public void TestMethodUnknowCharacter()
        {
            Assert.ThrowsException<ArgumentException>(() => { _t9Converter.ConvertString("4345"); });
        }

        [TestMethod]
        public void TestMethodNumbersWithCharacters()
        {
            Assert.ThrowsException<ArgumentException>(() => { _t9Converter.ConvertString("A"); });
        }

        [TestMethod]
        public void TestMethodIsCommon()
        {
            
            var t0 = _t9Converter.ConvertString(" ");
            var t1 = _t9Converter.ConvertString("hi");
            var t2 = _t9Converter.ConvertString("yes");
            var t3 = _t9Converter.ConvertString("foo  bar");
            var t4 = _t9Converter.ConvertString("hello world");
            var t5 = _t9Converter.ConvertString("uzfcnb");

            Assert.AreEqual("0", t0);
            Assert.AreEqual("44 444", t1);
            Assert.AreEqual("999337777", t2);
            Assert.AreEqual("333666 6660 022 2777", t3);
            Assert.AreEqual("4433555 555666096667775553", t4);
            Assert.AreEqual("8899993332226622", t5);
        }

        [TestMethod]
        public void TestMethodResultsHandlingNullableInput()
        {
            Assert.ThrowsException<NullReferenceException>(() => { _t9Converter.ConvertLines(null); });
        }
    }
}