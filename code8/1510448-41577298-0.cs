       public static string Every15(this string str) {
            if(str.Length < 15)
                return str;
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < str.Length; i++) {
                var ch = str[i];
                if(i % 15 == 0 && i != 0) {
                    builder.Append("\r\n");
                }
                builder.Append(ch);
            }
            return builder.ToString();
        }
