    public IslemVekil GirisYap(KisiGirisModel _kgm)
    {
        using (IslemVekil iv = new IslemVekil()) // first using
        using (KisiVekil kv = new KisiVekil()) // second using
        {
            iv = IslemVekilGetir(kv);
            return iv; // return here, because outside of this block 'iv' will be disposed
        }
        // return iv; - This is disposed and cannot be used
    }
