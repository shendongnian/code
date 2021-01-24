            public static object isReady(this StreamReader sr)
            {
                if ((sr.ReadLine()) != null)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
