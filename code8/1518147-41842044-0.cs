    class Program
        {
          static int Main(string[] args)
          {
            return AsynContent.Run(() => MainAsync(args));
          }
          
          static async Task<int> MainAsync(string[] args)
          {
            var taskList = new List<Task>();
            
            foreach (var item in itemList)
            {
              Task.Factory.StartNew(() => TranslationService.TranslateText(item.EnglishText, "french");
            }
            
            Task.WhenAll(taskList.ToArray());
          }
    }
