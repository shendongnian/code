    class aRecord
    {
        byte aByte { get; set; }
        long aLong { get; set; }
        string aString { get; set; }
        public aRecord() { }
        public aRecord(byte b_, long l_, string s_)
        { aByte = b_; aLong = l_; aString = s_; }
        public void writeToStream(BinaryWriter bw )
        {
            bw.Write(aByte);
            bw.Write(aLong);
            bw.Write(aString);
        }
        public void readFromStream(BinaryReader br)
        {
            aByte = br.ReadByte();
            aLong = br.ReadInt64();
            aString = br.ReadString();
        }
        static public aRecord readFromStream(BinaryReader br, int record)
        {
            int r = 0;
            aRecord  rec = new aRecord();
            br.BaseStream.Position = 0;
            while (br.PeekChar() != -1 & r <= record  )
            {
                rec.readFromStream(br);
                r++;
            }
            return rec;
        }
        static public aRecord readFromStream(BinaryReader br, string search)
        {
            aRecord rec = new aRecord();
            while (br.PeekChar() != -1 )
            {
                rec.readFromStream(br);
                if (rec.aString.Contains(search)) return rec;
            }
            return null;
        }
    }
