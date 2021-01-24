    var resultSets = Observable.Generate<ResultSet<IMessage>, IEnumerable<IMessage>>(
       //initial (empty) result
       new ResultSet<IMessage>(),
       
       //poll endlessly (until unsubscription)
       rs => true,
       //each polling iteration
       rs => 
       {
          //get the version from the previous result (which could be that initial result)
          int? previousVersion = rs.CurrentVersionHandle;
    
          //here's the problem, though: it won't work with async methods :(
    	  MessageResultSet messageResultSet = ReadLatestMessagesAsync(currentVersion).Result;
    	  return messageResultSet;
       },
       //we only care about spitting out the messages in a result set
       rs => rs.Messages, 
       //polling interval
       TimeSpan.FromMinutes(1),
       //which scheduler to run each iteration 
       TaskPoolScheduler.Default);
    return resultSets
      //project the list of messages into a sequence
      .SelectMany(messageList => messageList);
