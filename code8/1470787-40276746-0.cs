    var assistants =
                        dbContext.AssistantsTo
                            .Include(x => x.Assistant)
                            .Include(x => x.Assistant.CustomTagUser)
                            .Where(at =>
                                at.OwnerId == currentUser.UserId && 
    							(								
    								at.Assistant.CustomTagUser.Select(x => x.CustomTagId).Contains(filter)
                                )
                            .Select(at => at.Assistant)
                            .Distinct()
                            .ToList();		
