    public static void sorted(double[] testgrades, string[] names)
    {
        double temp = 0;
        string nameTemp = "";
        for (int write = 0; write < testgrades.Length; write++)
        {
            for (int sort = 0; sort < testgrades.Length - 1; sort++)
            {
                if (testgrades[sort] <= testgrades[sort + 1])
                {
                    temp = testgrades[sort + 1];
                    testgrades[sort + 1] = testgrades[sort];
                    testgrades[sort] = temp;
    
                    // If you move the grade to a different index, you need to move the corresponding grade
                    // as well
                    nameTemp = names[sort + 1];
                    names[sort + 1] = names[sort];
                    names[sort] = nameTemp;
                }
            }
        }
    }
