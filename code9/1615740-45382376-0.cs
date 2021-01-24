        async Task<Document> IDal.GetRecordAsync(string key, string value)
        {
            try
            {
                if (Database == null) ((IDal)this).StartConnection();
                var filter = Builders<BsonDocument>.Filter.Eq(key, value);
                var cursor = await Collection.FindAsync(filter);
                var bsondocument = cursor.FirstOrDefault();
                return bsondocument == null ? null : _converter.ConvertBsonDocumentToDocument(bsondocument);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
