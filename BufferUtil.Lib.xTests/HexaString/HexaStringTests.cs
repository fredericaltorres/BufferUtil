using System.Text;

namespace BufferUtil.Lib.xTests.BufferUtils
{
    public class HexaStringTests : BaseTestClass
    {
        [Fact]
        public void Parse()
        {
            var result = HexaString.Parse("0001020A");
            var expected = new List<byte> { 0, 1, 2, 10 };
            base.AssertBuffer(expected, result);
        }


        [Fact]
        public void Parse__WithInvalidLength()
        {
            Assert.Throws<ArgumentException>(() =>
                HexaString.Parse("0001020")
            );
        }

        [Fact]
        public void Parse__WithInvalidData()
        {
            Assert.Throws<FormatException>(() =>
                HexaString.Parse("0001020Z")
            );
        }
    }
}


