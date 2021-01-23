    public PageConstructor(PageViewModel viewModel)
            {
                this.BindingContext = viewModel;
                Listeners();
            }
    private void Listeners()
            {
                CategoriesList.ItemTapped += (sender, e) =>
                {
                    if (category.Selected == false)
                    {
                        App.DB.UpdateSelected(true);
                    }
                    else
                    {
                        App.DB.UpdateSelected(false);
                    }
                    categories = getCategories();
                    totalPhraseCount = getTotalPhraseCount();
                    Title = totalPhraseCount.ToString() + " phrases";
                };
            }
