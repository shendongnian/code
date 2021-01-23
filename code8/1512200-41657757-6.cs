        static async Task<int> HandleStreamResponse(StreamContent strm)
        {
            switch (strm.EntityType)
            {
                case StreamEntityType.Control:
                    var control = strm.Entity as Control;
                    Console.WriteLine("Control URI: {0}", control.URL);
                    break;
                case StreamEntityType.Delete:
                    var delete = strm.Entity as Delete;
                    Console.WriteLine("Delete - User ID: {0}, Status ID: {1}", delete.UserID, delete.StatusID);
                    break;
                case StreamEntityType.DirectMessage:
                    var dm = strm.Entity as DirectMessage;
                    Console.WriteLine("Direct Message - Sender: {0}, Text: {1}", dm.Sender, dm.Text);
                    break;
                case StreamEntityType.Disconnect:
                    var disconnect = strm.Entity as Disconnect;
                    Console.WriteLine("Disconnect - {0}", disconnect.Reason);
                    break;
                case StreamEntityType.Event:
                    var evt = strm.Entity as Event;
                    Console.WriteLine("Event - Event Name: {0}", evt.EventName);
                    break;
                case StreamEntityType.ForUser:
                    var user = strm.Entity as ForUser;
                    Console.WriteLine("For User - User ID: {0}, # Friends: {1}", user.UserID, user.Friends.Count);
                    break;
                case StreamEntityType.FriendsList:
                    var friends = strm.Entity as FriendsList;
                    Console.WriteLine("Friends List - # Friends: {0}", friends.Friends.Count);
                    break;
                case StreamEntityType.GeoScrub:
                    var scrub = strm.Entity as GeoScrub;
                    Console.WriteLine("GeoScrub - User ID: {0}, Up to Status ID: {1}", scrub.UserID, scrub.UpToStatusID);
                    break;
                case StreamEntityType.Limit:
                    var limit = strm.Entity as Limit;
                    Console.WriteLine("Limit - Track: {0}", limit.Track);
                    break;
                case StreamEntityType.Stall:
                    var stall = strm.Entity as Stall;
                    Console.WriteLine("Stall - Code: {0}, Message: {1}, % Full: {2}", stall.Code, stall.Message, stall.PercentFull);
                    break;
                case StreamEntityType.Status:
                    var status = strm.Entity as Status;
                    Console.WriteLine("Status - @{0}: {1}", status.User.ScreenNameResponse, status.Text);
                    break;
                case StreamEntityType.StatusWithheld:
                    var statusWithheld = strm.Entity as StatusWithheld;
                    Console.WriteLine("Status Withheld - Status ID: {0}, # Countries: {1}", statusWithheld.StatusID, statusWithheld.WithheldInCountries.Count);
                    break;
                case StreamEntityType.TooManyFollows:
                    var follows = strm.Entity as TooManyFollows;
                    Console.WriteLine("Too Many Follows - Message: {0}", follows.Message);
                    break;
                case StreamEntityType.UserWithheld:
                    var userWithheld = strm.Entity as UserWithheld;
                    Console.WriteLine("User Withheld - User ID: {0}, # Countries: {1}", userWithheld.UserID, userWithheld.WithheldInCountries.Count);
                    break;
                case StreamEntityType.ParseError:
                    var unparsedJson = strm.Entity as string;
                    Console.WriteLine("Parse Error - {0}", unparsedJson);
                    break;
                case StreamEntityType.Unknown:
                default:
                    Console.WriteLine("Unknown - " + strm.Content + "\n");
                    break;
            }
            return await Task.FromResult(0);
        }
