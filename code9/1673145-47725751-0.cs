    switch (country)
    {
        case "us":
            switch (type)
            {
                case "type1":
                    usType1Handler.Execute();
                    break;
                case "type2":
                    usType2Handler.Execute();
                    break;
                default:
                    break;
            }
            break;
        case "uk":
            switch (type)
            {
                case "type1":
                    ukType1Handler.Execute();
                    break;
                case "type2":
                    ukType2Handler.Execute();
                    break;
                default:
                    break;
            }
            break;
    }
