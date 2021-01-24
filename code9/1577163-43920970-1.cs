    decimal weight;                        //  AS Weight
    if (override != null && override == 1) // WHEN ISNULL(m.Override,0) = 1
    {
        weight = overWeight;               // THEN m.OverWeight
    }
    else
    {
        if (itemWeight != null)            // ELSE ISNULL(...)
            weight = itemWeight;           // itemWeight.Weight
        else
            weight = groupWeight;          // groupWeight.Weight
    }
    if (weight == 0)                       // NULLIF(..., 0)
    {
        weight = 5;                        // ISNULL(..., 5)
    }
