    public void Interpret(string s)
    {
        var extra = _packet.Consume(s);  // extra is if s has more than the data you are expecting
        if(_packet.Complete)
        {
           var location = packet.ToLocation()
        }
    }
