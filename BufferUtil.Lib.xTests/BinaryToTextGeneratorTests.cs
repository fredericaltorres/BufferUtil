namespace BufferUtil.Lib.xTests
{
    public class BinaryToTextGeneratorTests
    {
        public const string TEST_FILE_01 = @".\Files\TestFile01.txt";
        [Fact]
        public void Test1()
        {
            var bg = new BinaryToTextGenerator(TEST_FILE_01);
        }
    }
}