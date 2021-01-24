            private string DecimalToBase64(List<int> lst)
            {
                List<byte> arr = new List<byte>();
                foreach(int number in lst )
                {
                    arr.AddRange(BitConverter.GetBytes(number));
                }
                return Convert.ToBase64String(arr.ToArray());
            }
