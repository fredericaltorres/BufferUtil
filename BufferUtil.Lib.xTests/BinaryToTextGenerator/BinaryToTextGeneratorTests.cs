namespace BufferUtil.Lib.xTests
{

    public class BinaryToTextGeneratorTests  : BaseTestClass
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
