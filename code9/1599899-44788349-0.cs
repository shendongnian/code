    public static byte Checksum8XOR(byte[] data)
            {
                byte checksum = 0x00;
    
                for (int i = 0; i < data.Length; i++)
                {
    
                    checksum ^= data[i];
    
                }
    
    
                return checksum;
            }
