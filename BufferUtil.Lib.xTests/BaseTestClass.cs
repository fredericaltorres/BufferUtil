namespace BufferUtil.Lib.xTests
{
    public class BaseTestClass
    {
        public const string TEST_FILE_01 = @".\BinaryToTextGenerator\Files\TestFile01.txt";
        public const string TEST_FILE_02 = @".\BinaryToTextGenerator\Files\TestFile02.txt";
        public const string TEST_FILE_01_BYTE_PER_LINE_8 = @".\BinaryToTextGenerator\Files\TestFile01.BytePerLine8.txt";

        public string GetExpectedFile(string file)
        {
            var p = Path.GetDirectoryName(file);
            var n = Path.GetFileNameWithoutExtension(file);
            var e = Path.GetExtension(file);
            var r = Path.Combine(p, n + ".Expected" + e);

            if (!File.Exists(r))
                throw new ApplicationException($"Expected test file not found:{file}");

            return r;
        }

        public string GetExpectedFileContent(string file)
        {
            return File.ReadAllText(this.GetExpectedFile(file));
        }

        public void AssertBuffer(List<byte> b1, List<byte> b2)
        {
            if (b1.Count != b2.Count)
                throw new ArgumentException($"[AssertBuffer]Buffer1.Length:{b1.Count}, Buffer2.Length:{b2.Count} mismatch");
            for(var i = 0; i < b1.Count; i++)
            {
                if (b1[i] != b2[i])
                    throw new ArgumentException($"[AssertBuffer]Buffer1[{i}]:{b1[i]}, Buffer2[{i}]:{b2[i]} mismtach");
            }
        }
    }
}
