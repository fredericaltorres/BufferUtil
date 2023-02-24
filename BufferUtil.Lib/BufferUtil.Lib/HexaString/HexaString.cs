using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BufferUtil.Lib
{
    public class HexaString
    {

        /// <summary>
        /// A hexa string is bb0177af
        /// </summary>
        public static string ConvertTo(byte[] encrypted)
        {
            var result = "";

            foreach (var b in encrypted)
                result += $"{b.ToString("x")}";

            return result;
        }

        /// <summary>
        /// A hexa string is bb0177af
        /// </summary>
        /// <param name="hexaString"></param>
        /// <returns></returns>
        public static List<byte> Parse(string hexaString)
        {
            if (hexaString.Length % 2 == 0)
            {
                var r = new List<byte>();
                var chars = hexaString.ToCharArray().ToList();
                while (true)
                {
                    if (chars.Count > 0)
                    {
                        var c0 = chars[0]; chars.RemoveAt(0);
                        var c1 = chars[0]; chars.RemoveAt(0);
                        var hexaValue = c0.ToString() + c1.ToString();
                        var val = Convert.ToByte(hexaValue, 16);
                        r.Add(val);
                    }
                    else break;
                }
                return r;
            }
            else throw new ArgumentException($"Cannot parse hexa string wrong number of character {hexaString.Length}");
        }
    }
}
