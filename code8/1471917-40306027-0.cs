    List<int> playerIds = redisRespnse.Select(x => int.Parse(x)).ToList();
    using (var session = sessionFactory.OpenSession())
    {
            var players = session.Query<User>()
                .Where(user => playerIds.Contains(user.Id))
                .Select(user => user).ToList();
                
        }
        var finalResponse = new GetLeaderBoardResponse(players);
        return Ok(finalResponse);
    }
