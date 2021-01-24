    if (!string.IsNullOrEmpty(tweet.TweetText?.Trim()))
      {
           // Determine sentiment
           var postData2 = @"{""documents"":[{""id"":""1"", ""language"":""@language"", ""text"":""@sampleText""}]}".Replace(
                                "@sampleText", tweet.TweetText).Replace("@language", language);
                        var response2 = client.UploadString(SentimentUri, postData2);
                        var sentimentStr = new Regex(@"""score"":([\d.]+)").Match(response2).Groups[1].Value;
                        var sentiment = Convert.ToDouble(sentimentStr, System.Globalization.CultureInfo.InvariantCulture);
    
                        // Detemine key phrases
                        var postData3 = postData2;
                        var response3 = client.UploadString(KeyPhrasesUri, postData2);
                        var keyPhrases = new Regex(@"""keyPhrases"":(\[[^\]]*\])").Match(response3).Groups[1].Value;
    
        }
