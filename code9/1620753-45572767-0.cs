    public void SaveMethod(string t = "Test")
    {
        ((IOne)_base).Save(t);
        // or
        ((ITwo)_base).Save(t);
    }
