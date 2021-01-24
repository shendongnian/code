                string TestStr = "TestStr";
            byte[] TestStrAscii = System.Text.ASCIIEncoding.ASCII.GetBytes(TestStr.ToCharArray());
            foreach(byte bt in TestStrAscii)
            {
                System.Console.WriteLine(bt.ToString());
            }
