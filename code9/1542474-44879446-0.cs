            var channelInfo = (await client.SendRequestAsync<TeleSharp.TL.Contacts.TLResolvedPeer>(
                 new TeleSharp.TL.Contacts.TLRequestResolveUsername
                  {
                   username = "ChannelID"
                  }).ConfigureAwait(false)).chats.lists[0] as TeleSharp.TL.TLChannel;
                
                var Request = new TeleSharp.TL.Channels.TLRequestJoinChannel()
                {
                    channel = new TLInputChannel
                    {
                        channel_id = channelInfo.id,
                        access_hash = (long) channelInfo.access_hash
                    }
                };
                try
                {
                    var Respons = await client.SendRequestAsync<Boolean>(Request);
                }
                catch (exception ex)
                {
                }
