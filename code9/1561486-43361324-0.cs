    public static int GetHexFromName(string name)
    {
        switch (name)
        {
            case "Amaranth":
                return 0xE52B50;
            case "Amber":
                return 0xFFBF00;
            // Remaining 863 colors
            default:
                throw new ArgumentException();
        }
    }
    public static string GetNameFromHex(int hex)
    {
        switch (hex)
        {
            case 0xE52B50:
                return "Amaranth";
            case 0xFFBF00:
                return "Amber";
            // Remaining 863 colors
            default:
                throw new ArgumentException();
        }
    }
