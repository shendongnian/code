      using System.Runtime.InteropServices;
    
      ...
       
      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      public struct MyBitsField {
        private Byte m_Data; // We actually store Byte
    
        public MyBitsField(Byte data) {
          m_Data = data;
        }
    
        private bool GetBit(int index) {
          return (m_Data & (1 << index)) != 0;
        }
    
        private void SetBit(int index, bool value) {
          byte v = (byte)(1 << index);
    
          if (value)
            m_Data |= v;
          else
            m_Data = (byte) ((m_Data | v) ^ v);
        }
    
        public bool vesselPresenceSw {
          get { return GetBit(0); }
          set { SetBit(0, value); }
        }
    
        ...
    
        public bool motorDriverState {
          get { return GetBit(5); }
          set { SetBit(5, value); }
        }
      }
