     public static class encrypt
        {
            public static string encvalue(int id)
            {
                SecureQueryString qs = new SecureQueryString();
                qs["ID"] = id.ToString();
                return  qs.ToString()
            }
        }
