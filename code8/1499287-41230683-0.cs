    using (readNext = command.ExecuteReader())
    {
        while (readNext.Read())
        {
            abc = readNext.FieldCount;
            for (int s = 1; s < abc; s++)
            {
                var nextValue = readNext.GetValue(s);
            }
        }
    }
