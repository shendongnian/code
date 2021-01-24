        private async Task<List<Member>> GetMemberListAsync(string listId)
        {
            var offset = 0;
            var moreAvailable = true;
            var listMembers = new List<Member>();
          
            while (moreAvailable)
            {
                var result = await manager.Members.GetAllAsync(listId, new MemberRequest
                {
                    Status = Status.Subscribed,
                    Limit = 250,
                    Offset = offset
                });
                var resultList = result.ToList();
                foreach (var member in resultList)
                {
                    listMembers.Add(member);
                }
                if (resultList.Count() == 250)
                    offset += 250;
                else
                    moreAvailable = false;
            }
            return listMembers;
        }
