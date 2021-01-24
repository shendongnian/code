               DateTime now = DateTime.Now;
                long bNow = now.ToBinary();
                byte[] arrayNow = BitConverter.GetBytes(bNow);
                long getLong = BitConverter.ToInt64(arrayNow, 0);
                DateTime getNow = DateTime.FromBinary(getLong);
                Console.WriteLine(getNow.ToLongTimeString());
                Console.ReadLine();
