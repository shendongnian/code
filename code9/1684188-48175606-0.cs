    using (var reader = new StreamReader ("C://Users//HP//Documents//result2.txt")) 
    {
            string line = reader.ReadToEnd ();
            string res = line.Replace(line, "[", "");
            res  = res.Replace(line, "]", "");
            res  = res.Replace(line, "(", "");
            res  = res.Replace(line, ")", "");
            res  = res.Replace(line, "'", "");
            res  = res.Replace(line, ",", "");
            Message1.text = res;
        }
