    public void SetUp()
        {         
            for (int i = 1; i <= 6; i++)
            {
                temp = random.Next(1, 6);
                die = new Die(temp, "C:\\Users\\giorg\\Desktop\\dice\\dice" + temp + ".PNG");
                dices.Add(die); // list<Die> dices = new list<Die>();
            }
        }
