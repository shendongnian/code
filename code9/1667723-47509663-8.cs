    [HttpPost]
    public ActionResult PostCards(SelectedCardModel[] selectedCards) {
        foreach(var card in selectedCards) {
            if (card.IsSelected) {
                var selectedId = card.CardId;
                // ...
            }
        }
    }
