                YugiohRequester.GetAllCardsInSet(_selectedCardSet.Name).ContinueWith((result) =>
                {
                    //var cards = await YugiohRequester.GetAllCardsInSet(_selectedCardSet.Name);
                    try
                    {
                        this.mainPage.NavigateToYugiohCardListPage(result.Result);
                    }
                    catch (Exception e)
                    {
                        HelperFunctions.ShowToastNotification("Trading Card App", "Sorry, we could not fetch this set");
                    }
                }).Wait();
