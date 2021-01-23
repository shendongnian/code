        string path = @"path";
        System.IO.DirectoryInfo dir = System.IO.DirectoryInfo(path);
        foreach System.IO.FileInfo file in dir.GetFiles()){
            string newname = GetNewName(file.Name);
    if(newname!=file.Name)
            file.Move(file.FullName,  System.IO.Path.Combine(file.DiretoryName, newname);
        }
        
        public string GetNewName(string f){
           string without_ext = f.split('.').First();
        string result = f;
           Match m = Regex.Match(without_ext, "(\\d{4})(\\d[012]?)(\\d[0123]?\\d)")
            if(m.Success){
               result = $"{m.Groups[3].Value}.{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(m.Groups[2].Value)} {m.Groups[1].Value).{f.split('.').Last()}}; 
           }
           return result;
        }
