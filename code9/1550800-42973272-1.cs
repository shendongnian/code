        public static void Main()
        {
            // This is just an example. In your case you would read the text from a file
            const string text = @"x y
    xx yy
    xxx yyy";
            var lines = text.Split(new[]{'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            var xs = new string[lines.Length];
            var ys = new string[lines.Length];
            
            for(int i = 0; i < lines.Length; i++) 
            {
                var parts = lines[i].Split(' ');
                xs[i] = parts[0];
                ys[i] = parts[1];
            } 
        }
