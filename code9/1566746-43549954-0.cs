     public static class encrypt
        {
            public static string encvalue(int value)
            {
                SecureQueryString qs = new SecureQueryString();
                qs["ID"] = id.ToString();
                return  qs.ToString()
            }
        }
