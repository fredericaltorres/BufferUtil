namespace BufferUtil.Lib.xTests.BufferUtils
{


    public class BufferUtilTests : BaseTestClass
    {
        [Fact]
        public void UnitTest_Internal_AssertBuffer()
        {
            base.AssertBuffer(new List<byte> { }, new List<byte> { });
            base.AssertBuffer(new List<byte> { 0, 1, 2 }, new List<byte> { 0, 1, 2 });

            Assert.Throws<ArgumentException>(() => base.AssertBuffer(new List<byte> { 0, 1, 2 }, new List<byte> { 0, 1 }) );
            Assert.Throws<ArgumentException>(() => base.AssertBuffer(new List<byte> { 0, 1, 2 }, new List<byte> { 0, 1, 55 }));

        }

        [Fact]
        public void Generate_TextFiles()
        {
            var result = BufferUtil.BufferUtils.MakeBuffer(16, 0);
            var expected = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            base.AssertBuffer(expected, result);
        }
    }
}
