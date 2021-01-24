    void ListeningObjectTask()// Recieves any data sent by the other user.
            {
                while (client != null && client.Connected)// If there is another user and they are connected.
                {
                    try// This suppresses exceptions thrown by connection problems, such as the user losing network signal.
                    {
                        recieve = str.ReadLine();// Gets the data sent by the other user.
                        if (recieve != "")// If the user has sent data.
                        {
                            lock (recievedStrings)// Locks the buffer to add the data sent by the other user to it.
                            {
                                recievedStrings.Enqueue(recieve);
                            }
                            recieve = "";// Clears the incoming data, as it has been stored.
                        }
                    }
                    catch (Exception Ex)
                    {
                        // Ends all the other multiplayer objects as the connection has ended and they are no longer needed.
                        Disconnect();
                        // Tells the user why they have lost connection, so that they can try to fix the problem.
                        MessageBox.Show("Network connection ended\n" + Ex);
                    }
                }
            }
