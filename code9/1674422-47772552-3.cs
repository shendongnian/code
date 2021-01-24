        Random rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            double value = 0;
            double sum = 0;
            for (int j = 0; j < 10; j++)
            {
                value = rnd.Next(0, 1000);
                sum += value;
            }
            values.Add(sum / 10);
        }
