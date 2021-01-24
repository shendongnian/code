    ...
    var channel = new ChannelConf {
    Name = "Abc"
    Headers = !addNew ?  new Dictionary<string, string>  { [Constants.Key1] = Id }
              : new Dictionary<string, string> { [Constants.Key1] = Id, [Constants.Key2] = Port }
    }
    ...
