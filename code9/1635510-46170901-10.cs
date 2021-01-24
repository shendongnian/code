    public class ViewModelLocator 
    {
        // existing implementation goes here
        public async Task<TViewModel> Create<TViewodel>
        {
            var model = ServiceLocator.Current.GetInstance<TViewodel>(); 
            var activate = model as IActivate;
            if(activate != null)
                await activate.ActivateAsync();
            return model;
        }
    }
