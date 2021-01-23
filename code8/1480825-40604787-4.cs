            foreach (var SingleRow in modeltrainingtopic)
            {
    //It will count search term in your description , name and content
     int SearchCount = CountWords(SingleRow.Description, searchTerm) + CountWords(SingleRow.Name, searchTerm) + CountWords(SingleRow.Content, searchTerm);
    //Will add row to new list object named myFinalList 
                myFinalList.Add(
                  new YourListItems
                  {
                      Id = SingleRow.Id,
                      IsTrainingTopic = SingleRow.IsTrainingTopic,
                      Description = SingleRow.Description,
                      Content = SingleRow.Content,
                      Name = SingleRow.Name,
                      RedirectionLink = SingleRow.RedirectionLink,
                      SearchCount = SearchCount,
                  }
                );
            }
