     _client.SendMessageAsync(
                    new TLInputPeerUser()
                    {
                        user_id = channelUser.Id,
                        access_hash = channelUser.AccessHash
                    }
