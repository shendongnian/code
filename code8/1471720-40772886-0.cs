                        Console.WriteLine(_channel.Users);
                    var userPermissions = _user.GetPermissions(_channel).ManageMessages;
                    Console.WriteLine("Admin" + userPermissions);
                    int number = int.Parse(_parameter);
                    Message[] message = new Message[number];
                    message = _channel.DownloadMessages(number).Result;
                    if (userPermissions == true)
                    {
                        _channel.DeleteMessages(message);
                        Console.WriteLine("Channel Admin: " + _user + " deleted messages from the channel: " + _channel);
                    }
                    else
                    {
                        Console.WriteLine("User: " + _user + " tried to delete messages from: #" + _channel + " when they aren't an admin there.");
                    }
