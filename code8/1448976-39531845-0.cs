    var properties = this.GetType().GetProperties();
    for(int i = 0; i < n; i++)
    {
        var p = properties.Single(x => x.Name == "Receiver_" + i);
        var value = p.GetValue(this, 0);
    }
