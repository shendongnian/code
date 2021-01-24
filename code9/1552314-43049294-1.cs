    //This loop is unchanged
    foreach (ClientEntity client in connectedClients)
    {
        if (!isClientStillConnected(client.tcpClient)) {
            disconnectedClients.Add(client);
            client.tcpClient.Close();
            Debug.Log (" :: Client " + client.tcpClientName + " has disconnected! ::");
            continue;
        } else {
            Do_The_Stuff_And_Things();
            }
        }
    }
    //Remove all disconnected clients from the list of connected clients
    foreach (var disconnectedClient in disconnectedClients)
    {
        connectedClients.Remove(disconnectedClient);
    }
