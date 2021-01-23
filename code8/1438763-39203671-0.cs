                string text = "0a004c617374736e6e41";
                List<byte> output = new List<byte>();
                for (int i = 0; i < text.Length; i += 2)
                {
                    output.Add(byte.Parse(text.Substring(i,2), System.Globalization.NumberStyles.HexNumber));
                }
