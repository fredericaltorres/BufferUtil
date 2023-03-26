using System.Text;

namespace BufferUtil.Lib.xTests.BufferUtils
{
    public class HexaStringTests : BaseTestClass
    {
        [Fact]
        public void Build()
        {
            var input = new List<byte> { 0, 1, 2, 10 };
            var result = HexaString.ConvertTo(input.ToArray());
            var expected = "0001020A";
            Assert.Equal(expected, result);

            result = HexaString.ConvertTo(input.ToArray(), "x2");
            expected = "0001020a";
            Assert.Equal(expected, result);

            result = HexaString.ConvertTo(input.ToArray(), "x2");
            expected = "0001020a";
            Assert.Equal(expected, result);

            result = HexaString.ConvertTo(input.ToArray(), "x2", "{0}, ", "{0}");
            expected = "00, 01, 02, 0a";
            Assert.Equal(expected, result);
        }

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


