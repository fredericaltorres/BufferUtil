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

        [Fact]
        public void Generate_TextFiles_BitDisplayOn()
        {
            var inputTextFile = TEST_FILE_01;
            var bg = new BinaryToTextGenerator(inputTextFile);
            var defaultOptions = new BinaryViewerOption { ShowBinary = true };
            var result = bg.Generate(defaultOptions);

            var expected = GetSpecificFileContent(@".\BinaryToTextGenerator\Files\TestFile0.ShowBinary.Expected.txt");

            Assert.Equal(expected, result);
        }


        [Fact]
        public void Generate_TextFiles_DecimalDisplayOn()
        {
            var inputTextFile = TEST_FILE_01;
            var bg = new BinaryToTextGenerator(inputTextFile);
            var defaultOptions = new BinaryViewerOption { ShowDecimal = true };
            var result = bg.Generate(defaultOptions);

            var expected = GetSpecificFileContent(@".\BinaryToTextGenerator\Files\TestFile0.ShowDecimal.Expected.txt");

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
