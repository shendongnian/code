    using System;
    namespace PLCAddress
    {
        class Program
        {
            static void Main(string[] args)
            {
                PLCAddress a = new PLCAddress();
                float address;
                bool boolA = true;
                byte byteA = 7;
                ushort wordA = 65535;
                uint dblwordA = 4294967295;
            
                address = a.Store(boolA);
                Console.WriteLine(address.ToString());
                address = a.Store(boolA);
                Console.WriteLine(address.ToString());
                address = a.Store(byteA);
                Console.WriteLine(address.ToString());
                address = a.Store(boolA);
                Console.WriteLine(address.ToString());
                address = a.Store(wordA);
                Console.WriteLine(address.ToString());
                address = a.Store(dblwordA);
                Console.WriteLine(address.ToString());
            }
        }
        public class PLCAddress
        {
            protected uint _address;
            public PLCAddress()
            {
                _address = 0;
            }
            public float Store(bool b)
            {
                float rv = fAddress();
                _address += 1;
                return rv;
            }
            public float Store(byte b)
            {
                float rv = fAddress(8);
                _address += 8;
                return rv;
            }
            public float Store(ushort b)
            {
                float rv = fAddress(8); // use fAddress(16) if words need to be on word boundaries
                _address += 16;
                return rv;
            }
            public float Store(uint b)
            {
                float rv = fAddress(8); // use fAddress(32) if double words need to be on double word boundaries
                _address += 32;
                return rv;
            }
            protected float fAddress()
            {
                return (float)Whole + (float)Fraction / 10;
            }
            protected float fAddress(uint alignment)
            {
                uint roundup = alignment - 1;
                uint mask = ~roundup;
                uint AlignedAddress = _address + roundup;
                AlignedAddress = AlignedAddress & mask;
                _address = AlignedAddress;
                return fAddress();
            }
            protected uint Whole
            {
                get { return _address / 8; }
            }
            protected uint Fraction
            {
                get { return _address % 8;  }
            }
        }
    }
