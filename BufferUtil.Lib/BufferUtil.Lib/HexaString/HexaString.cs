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
        public static string ConvertTo(byte[] encrypted, string hexaFormat = "X2", string itemFormat = "{0}", string lastItemFormat = "{0}", int max = -1)
        {
            var result = new StringBuilder(1024);

            for(var i = 0; i < encrypted.Length; i++)
            {
                var b = encrypted[i];
                var hexaStr = $"{b.ToString(hexaFormat)}";

                if(i == encrypted.Length - 1) 
                    result.AppendFormat(lastItemFormat, hexaStr);
                else
                    result.AppendFormat(itemFormat, hexaStr);

                if (max != -1 && i == max-1)
                    break;
            }

            return result.ToString();
        }

        public static List<byte> ParseCSV(string hexaStringCsv)
        {
            var r = new List<byte>();
            var parts = hexaStringCsv.Split(',').Select(s => s.Trim()).ToList();
            foreach(var v in parts)
                r.Add(Convert.ToByte(v, 16));
            return r;
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
