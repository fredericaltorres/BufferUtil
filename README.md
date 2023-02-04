# BufferUtil

Library to manipulate bytes, byte buffers and generate text representation of files

	000000000 ┊ EF BB BF 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D ┊ ...ABCDEFGHIJKLM ┊ 
	000000001 ┊ 4E 4F 50 51 52 53 54 55 56 57 58 59 5A 0D 0A 41 ┊ NOPQRSTUVWXYZ..A ┊ 
	000000002 ┊ 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 ┊ BCDEFGHIJKLMNOPQ ┊ 
	000000003 ┊ 52 53 54 55 56 57 58 59 5A 0D 0A 41 42 43 44 45 ┊ RSTUVWXYZ..ABCDE ┊ 
	000000004 ┊ 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 52 53 54 55 ┊ FGHIJKLMNOPQRSTU ┊ 
	000000005 ┊ 56 57 58 59 5A 0D 0A                            ┊ VWXYZ..          ┊ 

# Remark

- Just started in 2023/02


# Methods

`csharp
public static List<byte> MakeBuffer(int len, byte val = 0);
public static List<byte> PadBuffer(List<byte> buffer, int len, byte paddingValue = 0);
public static void WriteBuffer(BinaryWriter writer, List<byte> buffer);
public static void WriteString(BinaryWriter writer, string s, int len);
public static List<byte> GenerateSectorBuffer(List<byte> buffer);
`