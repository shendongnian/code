     // Random generator for insulting
     private Random rgen = new Random();
     // 1st index - category (name/verb/insult), 2nd index item within category
     private static string[,] data;
     private static string[] categories = new string[] {
       "name", "verb", "insult", 
     }; 
     // Input single categore, e.g. Names or Verbs 
     private static void InputCategory(int category) {
       for (int i = 0; i < data.GetLength(1); ++i) {
         Console.Write($"Please enter {categories[category]} #{i + 1}: ");
         data[category, i] = Console.ReadLine();
       }         
     }
     // Input all categories 
     private static void InputData() {
       Console.Write($"Enter the number of names, verbs, and objects: ");
       // simplest; more accurate implementation uses int.TryParse()
       int n = int.Parse(Console.ReadLine());
       data = new string[categories.Length, n];
       foreach(var int i = 0; i < categories.Length; ++i) 
         InputCategory();
     }
