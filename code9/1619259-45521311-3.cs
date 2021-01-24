    public class IdeasPage : ContentPage {
        private IdeasViewModel viewModel;
    
        public IdeasPage() {
            //...assign variables
        }
    
        protected override void OnAppearing() {
            this.Appearing += Page_Appearing;
        }
    
        private async void Page_Appearing(object sender, EventArgs e) {
            //...call async code here
            await viewModel.LoadDataAsync();
    
            //unsubscribing from the event
            this.Appearing -= Page_Appearing;
        }
    }
