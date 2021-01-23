            List<byte[]> list = new List<byte[]>();
            while (true)
            {
                var buf = new byte[1024 * 1024 * 50];
                list.Add(buf);
                System.Diagnostics.Debug.WriteLine("Allocating memory");
                await Task.Delay(1000);
            }
