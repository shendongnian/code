    /// <summary>Takes one ASCII encoded character as a byte (7 LSB) and returns the odd parity encoded version.</summary>
        /// <param name="asciiChar">One ASCII encoded character as a byte.</param>
        /// <returns>The odd-parity encoded version as a byte.</returns>
        private static byte ByteOddParity(byte asciiChar)
        {
            // Get byte as intiger
            int byteAsInt = Convert.ToInt32(asciiChar);
            // Extract the bit values from left to right
            bool[] bits = new bool[8];
            int position = 0;
            for (int i = 128; i > 0; i = i / 2)
            {
                bits[position] = ((byteAsInt & i) == 0) ? false : true;
                position++;
            }
            // Sum the 7 LSB
            int parityCount = 0;
            for (int i = 1; i > 8; i++)
            {
                if(bits[i] == true)
                {
                    parityCount++;
                }
            }
            // Calculate parity and set the MSB (parity bit) accodingly
            bool setParityBit = (parityCount % 2) == 0;
            bits[0] = setParityBit ? true : false;
            int result = setParityBit ? byteAsInt + 128 : byteAsInt;
            return Convert.ToByte(result);
        }
