﻿namespace BufferUtil.Lib.xTests
{
    public class BassTest
    {
        public const string TEST_FILE_01 = @".\Files\TestFile01.txt";
        public const string TEST_FILE_02 = @".\Files\TestFile02.txt";

        public const string TEST_FILE_01_BYTE_PER_LINE_8 = @".\Files\TestFile01.BytePerLine8.txt";

        public string GetExpectedFile(string file)
        {
            var p = Path.GetDirectoryName(file);
            var n = Path.GetFileNameWithoutExtension(file);
            var e = Path.GetExtension(file);
            var r = Path.Combine(p, n + ".Expected" + e);
            return r;
        }

        public string GetExpectedFileContent(string file)
        {
            return File.ReadAllText(this.GetExpectedFile(file));
        }
    }

    public class BinaryToTextGeneratorTests  : BassTest
    {
        [Theory]
        [InlineData(TEST_FILE_02)]
        [InlineData(TEST_FILE_01)]
        public void Generate_TextFiles(string inputTextFile)
        {
            var bg = new BinaryToTextGenerator(inputTextFile);
            var defaultOptions = new BinaryViewerOption { };
            var result = bg.Generate(defaultOptions);

            var expected = GetExpectedFileContent(inputTextFile);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(TEST_FILE_01_BYTE_PER_LINE_8)]
        public void Generate_TextFiles_Option__BytePerLine8_LineNumberFormat(string inputTextFile)
        {
            var bg = new BinaryToTextGenerator(inputTextFile);
            var defaultOptions = new BinaryViewerOption { bytePerLine = 8, LineNumberFormat = "000", ShowFileInformation = false };
            var result = bg.Generate(defaultOptions);

            var expected = GetExpectedFileContent(inputTextFile);

            Assert.Equal(expected, result);
        }
    }
}
