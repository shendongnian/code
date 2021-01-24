    var filtered = myEnumerable.Where(item =>
        {
            var test = item.PropertyA == 1 || item.PropertyB == 2;
            if(test)
              return true; 
            var heavyResult = GetStuff(item); // Some heavyweight processing
            return heavyResult.IsSomethingTrue() && heavyResult.IsSomethingElseTrue();
        });
