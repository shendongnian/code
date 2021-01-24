    public void ColorInfo(string colorName)
    {
        Colors color = (Colors)Enum.Parse(typeof(Colors), colorName);
        switch (color)
        {
            case Colors.red:
                Debug.Print("red color");
                break;
        }
    }
