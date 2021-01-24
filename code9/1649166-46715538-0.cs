    public class SlideListItemViewModel : MvxViewModel
    {
        private long _id;
        private string _title;
        private IServerClient _serverClient;
    
        public long Id { get => _id; set => SetProperty(ref _id, value); }
    
        public string Title { get => _title; set => SetProperty(ref _title, value); }
    
        public IServerClient ServerClient {get => _serverClient; set => SetProperty(ref _serverClient, value; }
    
        public IMvxCommand DeleteCommand => new MvxCommand(DeleteCommandHandler);
    
        public async void DeleteCommandHandler()
        {
            var delete = await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
            {
                Title = "Delete slide",
                Message = "Are you sure you want to delete this slide?",
                OkText = "Yes",
                CancelText = "No"
            });
    
            if (!delete)
                return;
    
            //Here I should user my serverClient
        }
    }
