        public async Task UpdateDocumentAsync(string databaseName, string collectionName, int newAvailability) 
        {
            var taskList = new List<Task>();
            var collection = await this.GetDocumentCollectionAsync(databaseName, collectionName);
            var hotelRecords = client.CreateDocumentQuery<HotelMonthlyRecord>(collection.SelfLink)
                .Where(x => x.HotelCriteria.HotelName != null)
                .ToList();
            foreach (var item in hotelRecords)
            {
                item.RoomTypes.RoomTypeList.ForEach(i => i.Availability = newAvailability);
                taskList.Add(client.UpsertDocumentAsync(collection.SelfLink, item));
            }
            if (taskList.Any())
            {
                await Task.WhenAll(taskList);
            }
        }
