    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] names = {"Harry", "Tom"};
                var results = (from sc in Story_Character.story_character
                               join chr in Character.character on sc.Id_i equals chr.Id_i
                               join st in Story.story on sc.Id_i equals st.Id_i
                               join auth in Author.author on sc.Id_i equals auth.Id_i
                               where names.Contains(chr.Name_vc)
                               select new { sc = sc, chr = chr, st = st, auth = auth })
                              .GroupBy(x => x.sc.StoryId_i).Where(x => x.Count() >= 2).ToList();
            }
        }
        public class Story_Character
        {
            public static List<Story_Character> story_character = new List<Story_Character>();
            public int Id_i { get; set; }
            public int StoryId_i { get; set; }
            public int CharacterId_i { get; set; }
        }
        public class Character
        {
            public static List<Character> character = new List<Character>();
            public int Id_i { get; set; }
            public string Name_vc { get; set; }
        }
        public class Story
        {
            public static List<Story> story = new List<Story>();
            public int Id_i { get; set; }
            public DateTime Published_dt { get; set; }
            public string Title_vc { get; set; }
            public string AuthorId_i { get; set; }
        }
        public class Author
        {
            public static List<Author> author = new List<Author>();
            public int Id_i { get; set; }
            public string Name_vc { get; set; }
            public string Url_vc { get; set; }
        }
    }
