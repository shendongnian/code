                string input = "0802";
                List<byte> bytes = new List<byte>();
                for (int i = 0; i < input.Length; i += 2)
                {
                    bytes.Add(byte.Parse(input.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));
                }
