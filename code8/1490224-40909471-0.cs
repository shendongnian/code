     public TileSettings()
            {
                this.InitializeComponent();
                cts = new CancellationTokenSource();
                Task.Run(() => GetMessages(), cts.Token);
            }
            private async void GetMessages()
            {
                ChatMessageStore store;
                store = await ChatMessageManager.RequestStoreAsync();
                
                var List = store.GetMessageReader();
            }
