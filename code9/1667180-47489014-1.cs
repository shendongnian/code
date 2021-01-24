    [DebuggerDisplay("{CDBpp2()}")]
    [DebuggerDisplay("{DDBpp2()}")]
    public class A
    {
        [DebuggerDisplay("{DDBpp2()}", Name = "{DDBpp2()}", TargetTypeName = "{DDBpp2()}", Type = "{DDBpp2()}")]
        public byte[] Bpp { get; set; } = new byte[2] { 255, 255 };
        public byte[] Cpp { get; set; } = new byte[2] { 11, 28 };
        public string CDBpp2() => ToDebugStr(Cpp);
        public string DDBpp2() => ToDebugStr(Bpp);
        string ToDebugStr(byte[] b)
        {
            short result;
            if (BitConverter.IsLittleEndian)
            {
                var bppCopy = new byte[2];
                b.CopyTo(bppCopy, 0);
                Array.Reverse(bppCopy);
                result = BitConverter.ToInt16(bppCopy, 0);
            }
            else
            {
                result = BitConverter.ToInt16(b, 0);
            }
            return result.ToString();
        }
    }
 
