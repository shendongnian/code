    public ViewResult Wycieczki(String pesel)
        {
            var _ListKient = new List<Klient> { new Klient { pesel = "AA" }, new Klient { pesel = "BB" }, new Klient { pesel = "CC" }, new Klient { pesel = "DD" } };
            var wycieczka = (_ListKient.Klient).Where(c => c.pesel == pesel).Select(c => c.Wycieczki)).ToList();
            return View(wycieczka);
        }
