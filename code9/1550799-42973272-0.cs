        public static void Main()
        {
            const string text = @"x y
    xx yy
    xxx yyy";
            var lines = text.Split('\n');
            var xs = new string[lines.Length];
            var ys = new string[lines.Length];
            
            for(int i = 0; i < lines.Length; i++) 
            {
                var parts = lines[i].Split(' ');
                xs[i] = parts[0];
                ys[i] = parts[1];
            } 
        }
