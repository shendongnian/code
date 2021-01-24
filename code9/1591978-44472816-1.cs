    public class MainViewModel {
        public void CreateNewCard() {
            NewCardViewModel newCardModel = new NewCardViewModel();
            newCardModel.ChangePageCommand = new RelyCommand(Cancel);
            //...
        }
        void Cancel() {
    
        }
    }
    
    public class NewCardViewModel {
        public ICommand ChangePageCommand {
            get;
            set;
        }
    }
