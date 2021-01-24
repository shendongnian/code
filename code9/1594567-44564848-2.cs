    myListOfIMyObjects
        .GroupBy(x => x.GetType())
        .Select(x =>
            {
                var constr = x.Key.GetConstructor(Type.EmptyTypes);
                var instance = (IMyObject)constr.Invoke(new object[0]);
                instance.Value = x.Select(o => o.Value).Sum();
                return instance;
            })
        .ToList();
