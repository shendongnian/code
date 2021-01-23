        public static string DestroyPassword(string str )
        {
              var r = new Regex("-Password .*? ");//? in .net means not greedy
              return r.Replace(str, "-Password *** ");
        }
