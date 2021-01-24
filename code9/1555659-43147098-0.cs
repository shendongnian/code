    var tweets = matchingTweets.Select(item => new {
                                           property1 = item.property1,
                                           property2 = item.property2
                                       })
                               .Take(5).ToList();
