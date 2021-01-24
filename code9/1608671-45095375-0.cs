    public static object Create(this MyEnum enum)
    {
        switch (enum)
        {
             case MyEnum.First:
                  return new { IsFirst = true, UnitType = 1}];
             case MyEnum.Second:
                  return new ...
             default:
                  ...
        }
    }
