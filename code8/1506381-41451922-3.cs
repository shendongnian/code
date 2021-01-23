        static void Main(string[] args)
        {
            var p = new Program();
            Debug.Assert(p.IsValidFileSelection()==false);
            Debug.Assert(p.IsValidFileSelection("a.jpg")==true);
            Debug.Assert(p.IsValidFileSelection("a.png")==true);
            Debug.Assert(p.IsValidFileSelection("a.jpg", "a.png")==true);
            Debug.Assert(p.IsValidFileSelection("a.jpg", "a.png", "a.lfa")==false);
            Debug.Assert(p.IsValidFileSelection("a.lfa")==false);
            Debug.Assert(p.IsValidFileSelection("a.png",null)==false);
        }
