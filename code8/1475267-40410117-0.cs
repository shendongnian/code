    [TestMethod]
    public void NumeroSemaineTest()
    {
        //1 - Initialisation des variables
        DateTime DateTest = new DateTime(2016,11,3);
        List<int> expected = new List<int>(new int[] { 44, 45, 46, 47, 48 });
        List<int> actual;
        //2 - Appel de la méthode à tester
        actual = SaisieHeures.SaisieHeures.NumeroSemaine(DateTest);
        //3 - Vérification du résultat
        CollectionAssert.AreEqual(expected, actual);
        Assert.Inconclusive("Vérifiez l\'exactitude de cette méthode de test.");
    }
