using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace T9Lib.Tests
{
    using System.IO;

    using T9Common;

    [TestClass]
    public class T9SamplesTests
    {
        private IFileProvider _fileProvider = new FileProvider();

        [TestMethod]
        public void TestMethodWrongCharactersInPath()
        {
            Assert.ThrowsException<ArgumentException>(
                () => { _fileProvider.ReadFileLines(new FileInfo("d:\\adas..dw?")); });
        }

        [TestMethod]
        public void TestMethodFileNotExists()
        {
            Assert.ThrowsException<FileNotFoundException>(
                () => { _fileProvider.ReadFileLines(new FileInfo("z:\\reandom_file.xcxsa")); });
        }

        [TestMethod]
        public void TestMethodNullableFileInfo()
        {
            Assert.ThrowsException<NullReferenceException>(() => { _fileProvider.ReadFileLines(null); });
        }

        [TestMethod]
        public void TestMethodSuccessRead100Lines()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => { _fileProvider.ReadFileLines(new FileInfo("Samples\\C-small-practice_wrong_lines_count.in")); });
        }

        [TestMethod]
        public void TestMethodEmptyFile()
        {
            Assert.ThrowsException<ArgumentNullException>(
                () => { _fileProvider.ReadFileLines(new FileInfo("Samples\\C-small-practice_empty.in")); });
        }
    }
}