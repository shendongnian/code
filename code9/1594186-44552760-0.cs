    Public ViewResult Wycieczki (String pesel)
    {
    
        Var _ListKient = new list {new Klient {pesel = "AA"}, new Klient {pesel = "BB"}, new Klient {pesel = "CC"}, new Klient {pesel = "DD"}};
    
        Var wycieczka = (_ListKient.Klient).Where(c => c.pesel == pesel).Select (c => c.Wycieczki)).ToList();
    
        Return View(wycieczka);
    
    }
