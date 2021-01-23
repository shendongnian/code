     private List<TrelloCard> ProcessJobs(IQueryable<IGrouping<CardGrouping, Job>> jobs)
        {
            ConcurrentBag<TrelloCard> cards = new ConcurrentBag<TrelloCard>();
    
            Parallel.ForEach(jobs.ToList(), (job) => 
            {
               card = ProcessCards(job);  // I would like to run multiple instances of the processing
               cards.Add(card); //Once each instance is finshed it adds it to the list
            });
    
               return cards.ToList();
       }
    
      private TrelloCard ProcessCards(Job job)
        {
           return new TrelloCard();
        }
 
