    static async Task TranslateAllItems(IEnumerable<Item> list)
    {
         foreach(var item in itemList)
         {
             string result = await TranslationService.TranslateText(item.EnglishText, "french");
             UpdateMyDatabase(item.EnglishText, content);
         }
    }
    static void Main(string[] args)
    {
        Task task = TranslateAllItems(itemList);
        task.Wait();
        Console.ReadKey();
    }
