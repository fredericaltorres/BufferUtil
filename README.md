﻿# BufferUtil

Library to manipulate bytes, byte buffers and generate text representation of files

![Logo ](BufferUtil.50.png "Logo")

	000000000 ┊ EF BB BF 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D ┊ ...ABCDEFGHIJKLM ┊ 
	000000001 ┊ 4E 4F 50 51 52 53 54 55 56 57 58 59 5A 0D 0A 41 ┊ NOPQRSTUVWXYZ..A ┊ 
	000000002 ┊ 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 ┊ BCDEFGHIJKLMNOPQ ┊ 
	000000003 ┊ 52 53 54 55 56 57 58 59 5A 0D 0A 41 42 43 44 45 ┊ RSTUVWXYZ..ABCDE ┊ 
	000000004 ┊ 46 47 48 49 4A 4B 4C 4D 4E 4F 50 51 52 53 54 55 ┊ FGHIJKLMNOPQRSTU ┊ 
	000000005 ┊ 56 57 58 59 5A 0D 0A                            ┊ VWXYZ..          ┊ 
	
With bits/binary mode

	000000000 ┊ EF:11101111 BB:10111011 BF:10111111 41:01000001 42:01000010 43:01000011 44:01000100 45:01000101 46:01000110 47:01000111 48:01001000 49:01001001 4A:01001010 4B:01001011 4C:01001100 4D:01001101 ┊ ...ABCDEFGHIJKLM ┊ 
	000000001 ┊ 4E:01001110 4F:01001111 50:01010000 51:01010001 52:01010010 53:01010011 54:01010100 55:01010101 56:01010110 57:01010111 58:01011000 59:01011001 5A:01011010 0D:00001101 0A:00001010 41:01000001 ┊ NOPQRSTUVWXYZ..A ┊ 
	000000002 ┊ 42:01000010 43:01000011 44:01000100 45:01000101 46:01000110 47:01000111 48:01001000 49:01001001 4A:01001010 4B:01001011 4C:01001100 4D:01001101 4E:01001110 4F:01001111 50:01010000 51:01010001 ┊ BCDEFGHIJKLMNOPQ ┊ 
	000000003 ┊ 52:01010010 53:01010011 54:01010100 55:01010101 56:01010110 57:01010111 58:01011000 59:01011001 5A:01011010 0D:00001101 0A:00001010 41:01000001 42:01000010 43:01000011 44:01000100 45:01000101 ┊ RSTUVWXYZ..ABCDE ┊ 
	000000004 ┊ 46:01000110 47:01000111 48:01001000 49:01001001 4A:01001010 4B:01001011 4C:01001100 4D:01001101 4E:01001110 4F:01001111 50:01010000 51:01010001 52:01010010 53:01010011 54:01010100 55:01010101 ┊ FGHIJKLMNOPQRSTU ┊ 
	000000005 ┊ 56:01010110 57:01010111 58:01011000 59:01011001 5A:01011010 0D:00001101 0A:00001010 ┊ VWXYZ.. ┊ 


# Remarks

- Just started in 2023/02


# Methods


	public static List<byte> MakeBuffer(int len, byte val = 0);
	public static List<byte> PadBuffer(List<byte> buffer, int len, byte paddingValue = 0);
	public static void WriteBuffer(BinaryWriter writer, List<byte> buffer);
	public static void WriteString(BinaryWriter writer, string s, int len);
	public static List<byte> GenerateSectorBuffer(List<byte> buffer);

# Samples

```cssharp
  var bg = new BinaryToTextGenerator(inputTextFile);
  var defaultOptions = new BinaryViewerOption { ShowBinary = true };
  var result = bg.Generate(defaultOptions);
```
