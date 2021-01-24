    int count = deckManager.DeckAllCardsPlayer.Count;
    for(int a = 0; a < count; a++){
            int b = Random.Range(0, deckManager.DeckAllCardsPlayer.Count);
                if(!PlayerDeck.Contains(deckManager.DeckAllCardsPlayer[b])){
                PlayerDeck.Add(deckManager.DeckAllCardsPlayer[b]);
                deckManager.DeckAllCardsPlayer.RemoveAt(b);
            } 
        }
