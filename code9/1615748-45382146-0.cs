        BsonArray IPageCrawler.CrawlForTags(Uri url, HtmlDocument doc)
        {
            var bsonTagArray = new BsonArray();
            if (doc.DocumentNode.SelectNodes("//*[self::h1 or self::h2 or self::h3]") == null)
            {
                return null;
            }
            foreach (var tag in doc.DocumentNode.SelectNodes("//*[self::h1 or self::h2 or self::h3]"))
            {
                if (tag.InnerHtml.Contains("href"))
                {
                    var innerText = _contentHandler.CleanupString(tag.InnerText);
                    bsonTagArray.Add(new BsonDocument(new BsonElement(tag.Name, innerText)));
                }
                else
                {
                    var tagAtt = _contentHandler.CleanupString(tag.WriteContentTo());
                    bsonTagArray.Add(new BsonDocument(new BsonElement(tag.Name, tagAtt)));
                }
            }
            return bsonTagArray;
       }
