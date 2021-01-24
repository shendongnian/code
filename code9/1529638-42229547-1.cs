    var sum = selectedList
                .Distinct()
                .Sum(s =>
                {
                    decimal d;
                    if (cars.TryGetValue(s, out d))
                    {
                        return d;
                    }
                    return 0;
                }
            );
