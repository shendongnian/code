        for (var i = 0; i < numRequests; i++)
        {
            var thingsSet = things.Skip(i * 1000).Take(1000);
            
            // I may see your problem: Now with thingsSet we have true 
            // Enumerables of Thing, and the tests below are always false.
            // Hm.
            var carSet = thingsSet as IEnumerable<car>;
            var ballSet = thingsSet as IEnumerable<ball>;
            bool results;
            if(carSet != null ) { results = callOverLoadedFunction(carSet); }
            else if(ballSet != null) { results = callOverLoadedFunction(ballSet); }
            else { throw /*...*/}
        }
        
