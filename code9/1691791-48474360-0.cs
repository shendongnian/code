        class Program
        {
            public static List<CardSetWithWordCount> cardSetWithWordCounts;
            static void Main(string[] args)
            {
            }
            public object CheckCards()
            {
                string name = "";
                int count = 0;
                foreach(CardSetWithWordCount  card in cardSetWithWordCounts)
                {
                    if (card.IsToggled)
                    {
                        count++;
                        if(count == 1)
                        {
                                name = card.Name;
                        }
                        else
                        {
                            name = "mixed";
                            break;
                        }
                    }
                }
                if(name == "")
                    return null;
                else
                    return name;
            }
        }
        public class CardSetWithWordCount
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsToggled { get; set; }
            public int TotalWordCount { get; set; }
        }
