    var clients = BankManager.Instance.clients;
    var otherName = other.GetComponent<PlayerController>().name;
    int foundAt = -1;
    for(int i = 0; i < clients.Length; i++)
    {
        if(clients[i].name == otherName)
        {
            foundAt = i;
            break;
        }
    }
    claims = foundAt;
