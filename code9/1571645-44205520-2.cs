    public class AuditTests : INotifyPropertyChanged
    {
        public ObservableCollection<FileMeta> Files { get; set; }
        
        private void AddFileRequested()
        {
            Files.Add(new FileMeta());
            SaveFilesCommand.RaiseCanExecuteChanged();
        }
        private void RemoveFileRequested()
        {
            Files.Remove(SelectedUploadFile);
            SaveFilesCommand.RaiseCanExecuteChanged();
        }
        public void InitializeData()
        {
            Files = new ObservableCollection<FileMeta>() { new FileMeta () };
        }
    }
