    public class RecipeDetailViewModelArgs
    {
        public RecipeDetailViewModelArgs(RecipeModel recipe)
        {
            this.Recipe = recipe;
        }
        public RecipeModel Recipe { get; }
    }
    public class RecipeListViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService navigationService;
        public RecipeListViewModel(IMvxNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }
        private async Task SelectRecipe(RecipeModel recipe)
        {
            await this.navigationService.Navigate<RecipeDetailViewModel, RecipeDetailViewModelArgs>(new RecipeDetailViewModelArgs(recipe));
        }
    }
