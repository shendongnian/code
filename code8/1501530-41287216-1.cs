        class Telegram {
        public Telegram(byte[] tel) {
            // Check start bytes ( 0xa5, 0x5a );
            Info = tel[2];
            Counter = tel[3];
            Channel1 = BitConverter.ToInt16(new byte[] { tel[5], tel[4] }, 0); // Switch lo/hi byte
            Channel2 = BitConverter.ToInt16(new byte[] { tel[7], tel[6] }, 0);// Switch lo/hi byte
            // check tel[8] == 1 for end of telegram
         }    
         public int Info { get; private set; }
         public int Counter { get; private set; }
         public int Channel1 { get; private set; }
         public int Channel2 { get; private set; }
    }
