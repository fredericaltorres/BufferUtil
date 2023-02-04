namespace BufferUtil
{
    public class BinaryViewerOption
    {
        const string VERTICAL_BAR_SEPARATOR_ALONE = "\u250A";

        public bool ShowDecimal = false;
        public bool ShowBinary = false;
        public bool ShowHexaDecimal = true;
        public bool ShowSector = false;
        public int SectorSize = 512;
        public bool ShowAscii = true;
        public bool GenerateCArrayCode = false;
        public string VerticalBar = VERTICAL_BAR_SEPARATOR_ALONE;
        public int bytePerLine = 16;
        public bool ShowFileInformation = true;
    }
}

