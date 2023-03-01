using System;
using System.Collections.Generic;
using System.Linq;
using MadeInTheUSB.WinUtil;

namespace MadeInTheUSB.WinUtil
{
    public class BitUtilTests
    {
        [Fact]
        public void ExtractBits_1And2()
        {
            Assert.Equal(3, BitUtil.ExtractBit(255, 1, 2));
            Assert.Equal(1, BitUtil.ExtractBit(255-2, 1, 2));
            Assert.Equal(2, BitUtil.ExtractBit(255 - 1, 1, 2));
            Assert.Equal(0, BitUtil.ExtractBit(0, 1, 2));
        }
        [Fact]
        public void ExtractBits_3to8()
        {
            Assert.Equal(255-3, BitUtil.ExtractBit(255, 3,4,5,6,7,8));
        }

        [Fact]
        public void ExtractBits_1to4()
        {
            Assert.Equal(1+2+4+8, BitUtil.ExtractBit(255, 1, 2, 3, 4));
            Assert.Equal(1+4, BitUtil.ExtractBit(1+4, 1, 2, 3, 4));
            Assert.Equal(0, BitUtil.ExtractBit(0, 1, 2, 3, 4));
        }

        [Fact]
        public void ExtractBits_5To8()
        {
            Assert.Equal(128+64+32+16, BitUtil.ExtractBit(255, 5,6,7,8));
            Assert.Equal(0, BitUtil.ExtractBit(0, 5, 6, 7, 8));
        }

        [Fact]
        public void BitRprArrayToString_Build()
        {
            var s = BitUtil.BitRprArrayToString(new byte[] { 128+1, 64+2, 32+4, 16+8 });
            Assert.Equal("10000001010000100010010000011000", s);

            s = BitUtil.BitRprArrayToString(new byte[] { 255, 255 });
            Assert.Equal("1111111111111111", s);

            s = BitUtil.BitRprArrayToString(new byte[] { 255, 0, 255 });
            Assert.Equal("111111110000000011111111", s);
        }

        [Fact]
        public void BitRprArrayToString_Get_8_8_8_8()
        {
            var s = BitUtil.BitRprArrayToString(new byte[] { 128 + 1, 64 + 2, 32 + 4, 16 + 8 });
            Assert.Equal("10000001010000100010010000011000", s);

            var r = BitUtil.BitRprArrayGet(s, 8);
            Assert.Equal(128L + 1L, r.Value);

            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 8);
            Assert.Equal(64L + 2L, r.Value);

            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 8);
            Assert.Equal(32L + 4L, r.Value);

            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 8);
            Assert.Equal(16L + 8L, r.Value);
        }

        [Fact]
        public void BitRprArrayToString2_6_9()
        {
            var s = "01000000111111111000000";
            var r = BitUtil.BitRprArrayGet(s, 2);
            Assert.Equal(64L, r.Value);

            // Reserved
            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 6);
            
            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 9);
            Assert.Equal(255L+256L, r.Value);
        }


        [Fact]
        public void __BitRprArrayToString_2_AutoShiftRight()
        {
            var s = "0110";
            var r = BitUtil.BitRprArrayGet(s, 2, autoRightShift8: true);
            Assert.Equal(1L, r.Value);

            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 1, autoRightShift8: true);
            Assert.Equal(1L, r.Value);

            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 1, autoRightShift8: true);
            Assert.Equal(0L, r.Value);
        }

        [Fact]
        public void BitRprArrayToString_2_ShiftRight()
        {
            var s = "0110";
            var r = BitUtil.BitRprArrayGet(s, 2, shiftRight: 6);
            Assert.Equal(1L, r.Value);

            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 1, shiftRight:7);
            Assert.Equal(1L, r.Value);

            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 1, shiftRight: 7);
            Assert.Equal(0L, r.Value);
        }

        [Fact]
        public void BitRprArrayToString_2_1_1_2_2_3_3()
        {
            var s = "0110110000000000";
            var r = BitUtil.BitRprArrayGet(s, 2, shiftRight:6);
            Assert.Equal(1L, r.Value);

            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 1);
            Assert.Equal(128L, r.Value);

            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 1);
            Assert.Equal(0L, r.Value);

            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 2);
            Assert.Equal(128L+64L, r.Value);

            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 2);
            Assert.Equal(0L, r.Value);
        }


        [Fact]
        public void BitRprArrayToString_Getting24Bit()
        {
            var s = "100000011000000110000001"; // 8487297
            var r = BitUtil.BitRprArrayGet(s, 24);
            Assert.Equal(8487297L, r.Value);

        }

        [Fact]
        public void BitRprArrayToString_Getting22Bit_2Bit()
        {
            var s = "100000011000000110000001"; // 8487297
            var r = BitUtil.BitRprArrayGet(s, 22);
            Assert.Equal(2121824L, r.Value);
                        
            r = BitUtil.BitRprArrayGet(r.BitArrayDef, 2);
            Assert.Equal(64L, r.Value);

        }


        [Fact]
        public void BitRprArrayToString_SD_CARD_CID_Register()
        {
            var s = "000000100101010001001101010100110100000100110001001101100100011100100000000101010111001010101101101011100000000011110101101001010000001011000101";

            var r = new BitUtil.BitRprArrayToStringResult { BitArrayDef = s };

            r = BitUtil.BitRprArrayGet(r, 8);
            var manufacturer = r.ValueAsByte;
            Assert.Equal(2, manufacturer);

            r = BitUtil.BitRprArrayGetAsciiString(r, 2);
            Assert.Equal("TM", r.StringValue);

            r = BitUtil.BitRprArrayGetAsciiString(r, 5);
            Assert.Equal("SA16G", r.StringValue);

            r = BitUtil.BitRprArrayGet(r, 8);
            var revision = r.ValueAsByte;
            Assert.Equal(32, revision);

            r = BitUtil.BitRprArrayGet(r, 16);
            var v0 = r.Value;
            r = BitUtil.BitRprArrayGet(r, 16);
            var v1 = r.Value;
            var serial = ((v0 << 16) + v1);

            Assert.Equal(359837102L, serial);
        }

        [Fact]
        public void _BitRprArrayToString_SD_CARD_CSD_Register()
        {


            /*
01000000 ver+res 
00001110 tac 14
00000000 nasc 0
00110010 trabs speed 50
01011011 - 0101 ccc 12 bit
1001 - read_bl_len =9
00000000
0000000001110011010011110111111110000000000010100100000000000000                
             */

            var bits = "010000000000111000000000001100100101101101011001000000000000000001110011010011110111111110000000000010100100000000000000";
            var r = BitUtil.BitRprArrayGet(bits, 2, 6); // [0]:2
            var csd_ver = r.ValueAsByte;
            Assert.Equal(1, csd_ver);

            r = BitUtil.BitRprArrayGet(r, 6);// [0]:6
            var reserved1 = r.ValueAsByte;
            Assert.Equal(0, reserved1);

            Assert.Equal(8, r.BitCount);
            Assert.Equal(1.0, r.ByteCount);

            r = BitUtil.BitRprArrayGet(r, 8);// [1]:8
            var taac = r.ValueAsByte;
            Assert.Equal(14, taac);

            r = BitUtil.BitRprArrayGet(r, 8);// [2]:8
            var nsac = r.ValueAsByte;
            Assert.Equal(0, nsac);

            r = BitUtil.BitRprArrayGet(r, 8);// [3]:8
            var tran_speed = r.ValueAsByte;
            Assert.Equal(50, tran_speed);

            Assert.Equal(32, r.BitCount);
            Assert.Equal(4.0, r.ByteCount);

            r = BitUtil.BitRprArrayGet(r, 12);// [4]:8+[5:4]  // 0x32(50) to 5Ah(90)
            var ccc_high = r.ValueAsByte;
            Assert.Equal(181, ccc_high);

            r = BitUtil.BitRprArrayGet(r, 4, 4);// [5]:4
            var read_bl_len = r.ValueAsByte;
            Assert.Equal(9, read_bl_len);

        }

        [Fact]
        public void _xxx__BitRprArrayToString_32BitValue()
        {
            var s = "10000000000000000000000000000001";
            var r = BitUtil.BitRprArrayGet(s, 32);
            Assert.Equal(2147483648L+1L, r.Value);

            s = "10000000100000000000000000000001";
            r = BitUtil.BitRprArrayGet(s, 32);
            Assert.Equal(2147483648L + 8388608L + 1L, r.Value);

            s = "10000000100000001000000010000001";
            r = BitUtil.BitRprArrayGet(s, 32);
            Assert.Equal(2147483648L + 8388608L + 32768L+128L+1L, r.Value);
        }
    }
}
