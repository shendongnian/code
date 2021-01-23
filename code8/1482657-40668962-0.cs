    public ViewResult FullImage(int cardId)
    {
        Card card = repository.Cards.FirstOrDefault(p => p.CardID == cardId);
    {
        return View(cardId); // throws InvalidOperationException
    } ...(other closing brackets removed)
