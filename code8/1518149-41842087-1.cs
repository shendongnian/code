    static Task TranslateAllItems(IEnumerable<Item> list)
    {
         List<Task> waitingTasks = new List<Task>();
         foreach(var item in itemList)
         {
              string englishText = item.EnglishText;
              var task = TranslationService.TranslateText(englishText , "french")
                  .ContinueWith(taskResult => UpdateMyDatabase(englishText, taskResult.Result);
              waitingTasks.Add(task);
         }
         return Task.WhenAll(waitingTasks);
     }
    
