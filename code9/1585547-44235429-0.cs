    string str = "Test_AA_234_6874_Test";
    string substring = str.Substring(0, 4);
    if (substring == "Test" || substring == "Leaf")
    {
       str= str.Remove(0, 5);
    }
