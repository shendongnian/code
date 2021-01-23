        public static string DestroyPassword(string str )
        {
            var r = new Regex("-Password .*?($| -Address)");//? in .net means not greedy
            return r.Replace(str, "-Password ***$1");
        }
 
