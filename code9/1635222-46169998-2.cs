    public class SqlMembershipProviderHelper : SqlMembershipProvider
        {
            /// <summary>
            /// Used for decrypt password into plain text from encrypted type password
            /// </summary>
            /// <param name="encryptedPwd"></param>
            /// <returns></returns>
            public string GetClearTextPassword(string encryptedPwd)
            {
                byte[] encodedPassword = Convert.FromBase64String(encryptedPwd);
                byte[] bytes = this.DecryptPassword(encodedPassword);
                if (bytes == null)
                {
                    return null;
                }
                return Encoding.Unicode.GetString(bytes, 0x10, bytes.Length - 0x10);
            }
        }
