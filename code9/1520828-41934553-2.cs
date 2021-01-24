    var comments = new List<Comments>
            {
                new Comments{
                    CommunityId = community.FirstOrDefault(comid => comid.CommunityName == "TestCommunity")?.IdCommunity, //CommunityId should be nullable
                }
            };
