        abstract class Card
        {
            string name;
            abstract protected int GetInfo();
        }
        class Minion : Card
        {
            public int attack;
            protected override int GetInfo()
            {
                return this.attack;
            }
        }
        class Spell : Card
        {
            public int cost;
            protected override int GetInfo()
            {
                return this.cost;
            }
        }
        class Game
        {
            List<Card> cards;
            private void ReadCards()
            {
                cards = new List<Card>();
                //READ CARDS FROM DATABASE AND ADD TO COLLECTION
                //cards.Add(new Minion()) or cards.Add(new Spell())
            }
        }
