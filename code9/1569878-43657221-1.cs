    public MainViewModel(string param)
		{
			Messenger.Default.Register<DocumentViewModel>(this, ViewModelMessages.DocumentRequestClose,
				(DocumentViewModel o) =>
				{
					this.Documents.Remove(o);
					o.Cleanup();
					if( this.Documents.Count == 0)
						ActiveDocument = null;
				});
