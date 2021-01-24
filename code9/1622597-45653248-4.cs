    protected override void OnLoad(EventArgs e)
    {
         var from = Context.Request.QueryString["from"];
         switch(from.ToUpper())
         {
             case "EN": { lang = LanguageSetting.English; break; }
             case "JA": { lang = LanguageSetting.Japanese; break; }
         }
         if(lang == null) throw new Exception();
    }
    
