    var strArr = str.Split(',')
        .Select(x =>
        {
            int num;
            if (int.TryParse(x, out num))
            {
                return num;
            }
    
            return -1; // Or some other value or log it
        });
