            string randomString = "mypassword";
            string salt = "salt@gmail.com";
            //Setup Lists to take the extra byte of the byte array to the end
            var passArrList = new List<byte>();
            var saltArrList = new List<byte>();
            //Get the byte array of incoming passphrase
            byte[] passArr = Encoding.UTF8.GetBytes(randomString);
            //Add the pass byte array to the list
            passArrList.AddRange(passArr);
            //Append the needed 0x1 to the end of the array
            passArrList.Add(1);
            //Get the bytes of the salt
            byte[] saltArr = Encoding.UTF8.GetBytes(salt);
            //Add the salt to the list
            saltArrList.AddRange(saltArr);
            //Append the needed salt to the end
            saltArrList.Add(1);
            byte[] scryptBytes = CryptSharp.Utility.SCrypt.ComputeDerivedKey(passArrList.ToArray(), saltArrList.ToArray(), 262144, 8, 1, null, 32);
            Console.WriteLine(BitConverter.ToString(scryptBytes).Replace("-", ""));
