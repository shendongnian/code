            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            byte[] iterationCountBytes = BitConverter.GetBytes(iterationCount);
            int derivedLength = passwordBytes.Length + saltBytes.Length;
            byte[] passwordSaltBytes = new byte[derivedLength];
            byte[] pbkdf2Bytes;
            string encryptedString;
            for (int i = 0; i < passwordBytes.Length; i++)
            {
                passwordSaltBytes[i] = passwordBytes[i];
            }
            for (int i = 0; i < saltBytes.Length; i++)
            {
                passwordSaltBytes[passwordBytes.Length + i] = saltBytes[i];
            }
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, passwordSaltBytes, iterationCount))
            {
                pbkdf2Bytes = pbkdf2.GetBytes(derivedLength + iterationCountBytes.Length);
           
            }
