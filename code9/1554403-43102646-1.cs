    var enumValue = MyEnum.One;
    switch (enumValue)
    {
        case MyEnum.One:
            //Do Something here.
            break;
        case MyEnum.Two:
            //Do something else here.
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
