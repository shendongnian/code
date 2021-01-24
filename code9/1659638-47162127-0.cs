      FontFamily fontf = new FontFamily("Aharoni");
      System.Drawing.FontStyle fs = System.Drawing.FontStyle.Regular;
      System.Drawing.Font font;
      if (fontf.IsStyleAvailable(System.Drawing.FontStyle.Regular))
        fs = System.Drawing.FontStyle.Regular;
      else if (fontf.IsStyleAvailable(System.Drawing.FontStyle.Bold))
        fs = System.Drawing.FontStyle.Bold;
      else if (fontf.IsStyleAvailable(System.Drawing.FontStyle.Italic))
        fs = System.Drawing.FontStyle.Italic;
      else if (fontf.IsStyleAvailable(System.Drawing.FontStyle.Strikeout))
        fs = System.Drawing.FontStyle.Strikeout;
      else if (fontf.IsStyleAvailable(System.Drawing.FontStyle.Underline))
        fs = System.Drawing.FontStyle.Underline;
      else
         throw new Exception("No Font Styles Available");
      font = new System.Drawing.Font(fontf, 10, fs);
