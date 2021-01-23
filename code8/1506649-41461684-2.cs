    public class PasswordBLL
        {
            public static bool ValidatePassword(UserObjLibrary user, string Password)
            {
                return user.passwordHash == EncodePassword(Password, user.passwordSalt);
            }
    
            public static int ValidatePassword(string userName, string Password, string ipAddress, string MacAddress)
            {
                UserDAL ud = new UserDAL();
                UserObjLibrary user = ud.Details(userName:userName);
                user.lastActivity_ip = ipAddress;
                user.lastActive_MAC_address = MacAddress;
                if (user != null && user.userId > 0)
                    ud.LogInActivity(user);
                if(user == null || user.userId < 1)
                    return -1;
                return ValidatePassword(user,Password) ? user.userId : -2;
            }
    
            public static string GenerateSalt()
            {
                byte[] buf = new byte[16];
                (new RNGCryptoServiceProvider()).GetBytes(buf);
                return Convert.ToBase64String(buf);
            }
    
            public static string EncodePassword(string pass, string salt)
            {
                try
                {
                    byte[] bytes = Encoding.Unicode.GetBytes(pass);
                    byte[] src = Convert.FromBase64String(salt);
                    byte[] dst = new byte[src.Length + bytes.Length];
                    byte[] inArray = null;
                    Buffer.BlockCopy(src, 0, dst, 0, src.Length);
                    Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
    
                    HashAlgorithm algorithm = HashAlgorithm.Create("SHA512");
                    inArray = algorithm.ComputeHash(dst);
    
                    return Convert.ToBase64String(inArray);
                }
                catch (Exception ex)
                {
                    // This gets thrown if the salt is invalid
                    return "--Invalid--";   // Any non empty value is fine to make sure the match fails
                }
            }
        }
