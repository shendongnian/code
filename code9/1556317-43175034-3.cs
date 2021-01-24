    int NewID = Convert.ToInt32(Adapter.InsertQuery()); // new relationship id
    if (!Session.GetHabbo().Relationships.ContainsKey(Them))
    { // Added here
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
            { // Added here.
                Session.SendMessage(new FriendListUpdateComposer(Session, Bud));
            }
        }
        return false;
    }
