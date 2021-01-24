    public async Task GoToCardCommnunity()
    {
      var currentPage = GetCurrentPage();
      await currentPage.Navigation.PushAsync(new CardCommunityPage());
    }
