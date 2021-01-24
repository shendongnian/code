    int NewID = Convert.ToInt32(Adapter.InsertQuery()); // new relationship id
    if (!Session.GetHabbo().Relationships.ContainsKey(Them))
        Session.GetHabbo().Relationships.Add(Them, new Relationship(NewID, Them, 3)); // create the relationship
        Session.GetHabbo().GetMessenger().UpdateFriend(Them, Session, true);
    }
    else
    {
        Habbo Habbo = PlusEnvironment.GetHabboById(Them);
        if (Habbo != null)
        {
            MessengerBuddy Bud = null;
            if (Session.GetHabbo().GetMessenger().TryGetFriend(Them, out Bud))
                Session.SendMessage(new FriendListUpdateComposer(Session, Bud));
            }
        }
        return false;
    }
