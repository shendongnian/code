    void Update()
    {
        var color = switchOn ? new Color(255, 255, 255, 0) : new Color(255, 255, 255, 1);
        var multiplier = switchOn ? 0.0075f : 0.005f;
        for (int j = 0; j < 4; j++)
        {
            TextMesh TextColor = AllText[j].GetComponent<TextMesh>();
            TextColor.color = Color.Lerp(TextColor.color, color, multiplier * Time.time);
            if ((switchOn && TextColor.color.a <= 0.023f) || (!switchOn && TextColor.color.a >= 0.977f))
            {
                TextColor.color = color;
                if ()
                {
                    switchOn = false;
                    switchOff = false;
                    newSwitchOne = !switchOn;
                    newSwitchTwo = switchOn;
                }
            }
        }
    }
