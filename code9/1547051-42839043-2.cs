     class SomePage : Form
    {
        void ShowVisualFeedBack()
        {
            ...
        }
        void HideVisualFeedBack()
        {
            ...
        }
        private async Task ShowDetailView()
        {
            this.ShowVisualFeedBack();
            this.DetailView = new MyView();
            await view.LoadContent();
            this.HideVisualFeedBack();
         }
    }
