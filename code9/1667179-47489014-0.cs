    [DebuggerDisplay("{DDBpp2()}")]
    public class A
    { 
        [DebuggerDisplay("{DDBpp2()}", Name = "{DDBpp2()}", TargetTypeName = "{DDBpp2()}", Type = "{DDBpp2()}"]
        public byte[] Bpp { get; set; } = new byte[2];
 
        public string DDBpp2()
        {
            short result;
            if (BitConverter.IsLittleEndian)
            {
                var bppCopy = new byte[2];
                Bpp.CopyTo(bppCopy, 0);
                Array.Reverse(bppCopy);
                result = BitConverter.ToInt16(bppCopy, 0);
            }
            else
            {
                result = BitConverter.ToInt16(Bpp, 0);
            }
            return result.ToString();
        } 
    }
