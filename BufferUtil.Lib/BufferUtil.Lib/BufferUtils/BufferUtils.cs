using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BufferUtil
{
    public class BufferUtils
    {
        const int SECTOR_SIZE = 512;
        public static List<byte> MakeBuffer(int len, byte val = 0)
        {
            var buffer = new List<byte>();
            for(int i = 0; i < len; i++)
                buffer.Add(val);
            return buffer;
        }
        public static List<byte> PadBuffer(List<byte> buffer, int len, byte paddingValue = 0)
        {
            if(buffer.Count < len)
            {
                buffer.AddRange(MakeBuffer(len-buffer.Count, paddingValue));
            }
            return buffer;
        }

        public static List<byte> FinalizeWriter(BinaryWriter writer)
        {
            writer.BaseStream.Flush();
            var count = (int)writer.BaseStream.Length;
            var buffer = ((MemoryStream)writer.BaseStream).GetBuffer().ToList();
            return buffer.Take(count).ToList();
        }

        public static void WriteBuffer(BinaryWriter writer, List<byte> buffer)
        {
            writer.Write(buffer.ToArray(), 0, buffer.Count);
        }
        public static void WriteString(BinaryWriter writer, string s, int len)
        {
            var f = s.PadRight(len,' ').Substring(0, len);
            writer.Write(f.ToCharArray(), 0, len);
        }

        public static List<byte> GenerateSectorBuffer(List<byte> buffer)
        {
            var tmpBuffer = PadBuffer(buffer, SECTOR_SIZE);
            if (tmpBuffer.Count > SECTOR_SIZE)
                throw new System.ArgumentException("buffer cannot be more than 512 bytes");

            return tmpBuffer;
        }

        static int FindSequence(byte[] buffer, byte[] sequence, int startIndex = 0)
        {
            if (sequence.Length == 0) return -1; // No sequence to find
            if (buffer.Length < sequence.Length) return -1; // Buffer is too small to contain the sequence

            for (int i = startIndex; i <= buffer.Length - sequence.Length; i++)
            {
                bool found = true;
                for (int j = 0; j < sequence.Length; j++)
                {
                    if (buffer[i + j] != sequence[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found) return i; // Sequence found at index i
            }

            return -1; // Sequence not found
        }

        public static List<byte> SearchForSequence(string fileName, List<byte> startSequence, List<byte> endSequence)
        {
            var buffer = File.ReadAllBytes(fileName).ToList();
            return SearchForSequence(buffer, startSequence, endSequence);
        }

        public static List<byte> SearchForSequence(List<byte> buffer, List<byte> startSequence, List<byte> endSequence)
        {
            var start = FindSequence(buffer.ToArray(), startSequence.ToArray());
            if (start == -1)
                return null;

            var end = FindSequence(buffer.ToArray(), endSequence.ToArray(), startIndex: start+1);
            if (end == -1)
                return null;

            return buffer.GetRange(start+ startSequence.Count, end - start - endSequence.Count);
        }

        public static List<byte> Invoke(List<byte> buffer, List<byte> startSequence, List<byte> endSequence)
        {
            return SearchForSequence(buffer, startSequence, endSequence);
        }
    }
}
