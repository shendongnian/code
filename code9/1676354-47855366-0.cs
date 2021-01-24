    var myHero = new Hero();
    myHero.Armor += 5;
    SomeMethod(myHero);
    // elsewhere...
    void SomeMethod(Hero aHero)
    {
        // here, "aHero" has an armor increased by 5
    }
