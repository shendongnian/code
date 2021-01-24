    private string mReplace(string txt)
        {
            string sonuc;
            if (txt == null) { return ""; }
            txt = txt.Replace(" ", " ");
            txt = txt.Replace("-", " ");
            txt = txt.Replace("ç", "C");
            txt = txt.Replace("Ç", "C");
            txt = txt.Replace("ı", "I");
            txt = txt.Replace("i", "I");
            txt = txt.Replace("İ", "I");
            txt = txt.Replace("ğ", "G");
            txt = txt.Replace("Ğ", "G");
            txt = txt.Replace("ö", "O");
            txt = txt.Replace("Ö", "O");
            txt = txt.Replace("ş", "S");
            txt = txt.Replace("Ş", "S");
            txt = txt.Replace("ü", "U");
            txt = txt.Replace("Ü", "U");
            sonuc = txt.ToUpper();
            return sonuc;
        }
