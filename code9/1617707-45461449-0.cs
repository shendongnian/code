    var names = new List<string>();
    foreach(var client in wclients){
        if (client.message == "success")
        {
            names.Add("name = " + client.data.name);
        }
    }
