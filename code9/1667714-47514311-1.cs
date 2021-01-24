    Message messageAlias = null;
    MessageDTO messageDto = null;
    
    var projection = Projections.Conditional(
         Subqueries.Exists(QueryOver.Of<UserMessageFavourite>()
                           .Where(f => f.Message.Id == messageAlias.Id).DetachedCriteria)),
         Projections.Constant(true),
         Projections.Constant(false));
    
    var messages = GetSessionFactory().GetCurrentSession()
        .QueryOver<Message>(() => messageAlias)
        .SelectList(list => list
            .Select(() => messageList.Id).WithAlias(() => messageDto.Id)
            .Select(() => messageList.Title).WithAlias(() => messageDto.Title)
            .Select(projection).WithAlias(() => messageDto.IsFavorite)
        )
