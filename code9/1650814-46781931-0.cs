    static public void writeLn(string s)
        {
            Window1 fm = Application.OpenForms.OfType<Window1>().Take(1).SingleOrDefault();
            if (fm != null)
               fm.writeLn(s);
        }
