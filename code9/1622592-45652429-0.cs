    public enum Language {
        En_Ja,
        Ja_En
    }
    Language lang = Language.En_Ja;
     public  void Switch(object sender, EventArgs e) {
         lang = lang == Language.En_Ja ? Language.Ja_En : Language.En_Ja;
     }
