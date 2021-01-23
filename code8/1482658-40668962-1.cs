    public ViewResult FullImage(int cardId)
    {
        Card card = repository.Cards.FirstOrDefault(p => p.CardID == cardId);
    {
        return View(card); // returning model class, not a passed property id
    } ...(other closing brackets removed)
