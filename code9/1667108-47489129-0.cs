    function clientValidate(source, args)
    {
    //sender is <span...>err</span> extended properties include controltovalidate
    //args is {Value: 123, IsValid: true}
        if (parseInt(args.Value) < 10)
        {
            args.IsValid = false; //not source and no return
            //other logic
        }
        else
        {
            //args.IsValid = true; //redundant. **true** is default value
            //return source.IsValid = true; //see above
            //other logic
        }
    }
