    // How to initialize deck
    PlayingCard[] deck = Enumerable.Range(0, 52)
                            .Select(x => new PlayingCard(x % 13, x / 13, imageListCards[x]))
                            .ToArray();
    // How to shuffle deck
    Random r = new Random();
    Array.Sort(deck, (a, b) => r.Next(0, 2) == 0 ? -1 : 1);
    // How to reset deck
    Array.Sort(deck);
    // How to display top five cards
    pictureBox_Card1.Image = deck[0].CardImage;
    pictureBox_Card2.Image = deck[1].CardImage;
    pictureBox_Card3.Image = deck[2].CardImage;
    pictureBox_Card4.Image = deck[3].CardImage;
    pictureBox_Card5.Image = deck[4].CardImage;
