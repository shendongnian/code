    public IslemVekil GirisYap(KisiGirisModel _kgm)
        {
            IslemVekil iv;
    
            using (KisiVekil kv = new KisiVekil())
            {
                iv = IslemVekilGetir(kv);
            }
    
            return iv;
        }
    
    public void Test(KisiGirisModel _kgm)
        {
              
            using (IslemVekil iv = GirisYap(_kgm))
            {
                ...
            }
    
        }
