    private async Task GetYugiohCardsAndNavigate(string name)
    {
        try
        {
            var cardSetData  = await YugiohRequester.GetAllCardsInSet(_selectedCardSet.Name);
            this.mainPage.NavigateToYugiohCardListPage(cardSetData);
        }
        catch (Exception e)
        {
            HelperFunctions.ShowToastNotification("Trading Card App", 
                                                  "Sorry, we could not fetch this set");
        }
    }
