    var favList = context.FavoriteMessages
            .Where(m => m.UserId == user.UserId && m.OnlineRoomId == user.OnlineRoomId)
            .Select(m => new {
                m.UserId,   // return user id from database
                m.Instance,
                m.CreatedOn
            })
            .AsEnumerable() // further part of query is not translated into SQL
            .Select(i => new {
                UserName = userService.GetUserById(i.UserId).Name, // get name locally
                i.Instance,
                i.CreatedOn
            }).ToList();
