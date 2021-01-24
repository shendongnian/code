    public void Main() {
        string name1 = "John";
        string name2 = "Alexander";
        string FullName = name1.FixLeft(7) + name2.FixLeft(7);
        Console.WriteLine(FullName);
    }
    private static string FixLeft(this string TextInput, int DesiredLength) {
        if (TextInput.Length < DesiredLength) {return TextInput.PadRight(DesiredLength); }
        else { return TextInput.Substring(0,7);
    }
    }
