    public class RecipeDetailViewModel : MvxViewModel<RecipeDetailViewModelArgs>
    {
        private readonly IMvxViewModelLoader mvxViewModelLoader;
        private readonly IMvxJsonConverter jsonConverter;
        private RecipeModel recipe;
        public RecipeDetailViewModel(IMvxViewModelLoader mvxViewModelLoader, IMvxJsonConverter jsonConverter)
        {
            this.mvxViewModelLoader = mvxViewModelLoader;
            this.jsonConverter = jsonConverter;
        }
        public override void Prepare(RecipeDetailViewModelArgs parameter)
        {
            this.recipe = parameter.Recipe;
        }
        protected override void SaveStateToBundle(IMvxBundle bundle)
        {
            base.SaveStateToBundle(bundle);
            bundle.Data["RecipeKey"] = this.jsonConverter.SerializeObject(this.recipe);
        }
        protected override void ReloadFromBundle(IMvxBundle state)
        {
            base.ReloadFromBundle(state);
            this.recipe = this.jsonConverter.DeserializeObject<RecipeModel>(state.Data["RecipeKey"]);
        }
        public override async Task Initialize()
        {
            await base.Initialize();
            this.InitializeChildrenViewModels();
        }
        public RecipeFlavoursViewModel FlavoursViewModel { get; private set; }
        public RecipeIngridientsViewModel IngredientsViewModel { get; private set; }
        protected virtual void InitializeChildrenViewModels()
        {
            // Load each childre ViewModel and set the recipe
            this.FlavoursViewModel = this.mvxViewModelLoader.LoadViewModel(new MvxViewModelRequest<RecipeFlavoursViewModel>(null, null), null);
            this.FlavoursViewModel.Recipe = this.recipe;
            this.IngredientsViewModel = this.mvxViewModelLoader.LoadViewModel(new MvxViewModelRequest<RecipeIngridientsViewModel>(null, null), null);
            this.FlavoursViewModel.Recipe = this.recipe;
        }
    }
