using System.Text;

namespace BufferUtil.Lib.xTests.BufferUtils
{
    public class BufferUtilTests : BaseTestClass
    {
        [Fact]
        public void UnitTest_Internal_AssertBuffer()
        {
            base.AssertBuffer(new List<byte> { }, new List<byte> { });
            base.AssertBuffer(new List<byte> { 0, 1, 2 }, new List<byte> { 0, 1, 2 });

            Assert.Throws<ArgumentException>(() => base.AssertBuffer(new List<byte> { 0, 1, 2 }, new List<byte> { 0, 1 }));
            Assert.Throws<ArgumentException>(() => base.AssertBuffer(new List<byte> { 0, 1, 2 }, new List<byte> { 0, 1, 55 }));
        }

        [Fact]
        public void MakeBuffer()
        {            
            var result = BufferUtil.BufferUtils.MakeBuffer(16, 0);
            var expected = new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            base.AssertBuffer(expected, result);
        }

        [Fact]
        public void PadBuffer()
        {
            var result = BufferUtil.BufferUtils.PadBuffer(new List<byte> { 1 }, 3, 64);
            var expected = new List<byte> { 1, 64, 64 };
            base.AssertBuffer(expected, result);
        }

        BinaryWriter CreateBinaryWriter()
        {
            MemoryStream memStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memStream);
            return writer;
        }

        [Fact]
        public void WriteBuffer()
        {
            using (var writer = CreateBinaryWriter())
            {
                var sourceBuffer = new List<byte> { 1, 2, 3 };
                BufferUtil.BufferUtils.WriteBuffer(writer, sourceBuffer);
                var buffer = BufferUtil.BufferUtils.FinalizeWriter(writer);
                Assert.Equal(sourceBuffer.Count, buffer.Count);
                base.AssertBuffer(sourceBuffer, buffer);
            }
        }


        [Fact]
        public void WriteString()
        {
            using (var writer = CreateBinaryWriter())
            {
                var fileName = "Fred4Kb.jpg";
                BufferUtil.BufferUtils.WriteString(writer, fileName, fileName.Length);
                var buffer = BufferUtil.BufferUtils.FinalizeWriter(writer);
                var expected = Encoding.ASCII.GetBytes(fileName).ToList();

                base.AssertBuffer(expected, buffer);
            }
        }

        [Fact]
        public void GenerateSectorBuffer()
        {
            using (var writer = CreateBinaryWriter())
            {
                var sourceBuffer = new List<byte> { 0, 0, 0 };
                var buffer = BufferUtil.BufferUtils.GenerateSectorBuffer(sourceBuffer);
                var expected = BufferUtil.BufferUtils.MakeBuffer(512, 0);
                base.AssertBuffer(expected, buffer);
            }
        }

        [Fact]
        public void GenerateSectorBuffer_TooBig()
        {
            using (var writer = CreateBinaryWriter())
            {
                var sourceBuffer = BufferUtil.BufferUtils.MakeBuffer(512+1, 0);
                Assert.Throws<ArgumentException>(() => BufferUtil.BufferUtils.GenerateSectorBuffer(sourceBuffer));
            }
        }
    }
}
