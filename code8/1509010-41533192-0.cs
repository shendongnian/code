                string input = "0B00FEE99CF002000CEF02000B00FEE81A9A9F60FFFFB8570B00FEE042522500425225000B00FEE5E0530100C89F0400";
                List<byte> bytes = new List<byte>();
                for (int i = 0; i < input.Length; i += 2)
                {
                    byte newByte = byte.Parse(input.Substring(i,2), System.Globalization.NumberStyles.HexNumber);
                    bytes.Add(newByte);
                }
