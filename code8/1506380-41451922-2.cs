    class Program
    {
        static readonly string[] valid_ext = new[] { ".jpg", ".png" };
        public bool IsValidFileSelection(params string[] filenames)
        {
            
            if(filenames==null) return false;
            if(filenames.Length==0) return false;
            foreach(var item in filenames)
            {
                if(string.IsNullOrEmpty(item)) return false;
                if(!valid_ext.Contains(Path.GetExtension(item)))
                {
                    return false;
                }
            }
            return true;
        }
    }
