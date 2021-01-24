    QuickFix.Fields.NoPartyIDs noPartyIDs = new QuickFix.Fields.NoPartyIDs(1);
                QuickFix.Fields.PartyID partyID = new QuickFix.Fields.PartyID(lp);
                QuickFix.Fields.PartyIDSource partyIDSource = new QuickFix.Fields.PartyIDSource('D');
                QuickFix.Fields.PartyRole partyRole = new QuickFix.Fields.PartyRole(35);
    
              QuickFix.FIX44.Quote.NoPartyIDsGroup group = new Quote.NoPartyIDsGroup();
    
                group.SetField(noPartyIDs);
                group.SetField(partyRole);
                group.SetField(partyIDSource);
                group.SetField(partyID);
    
                message.AddGroup(group);
                
