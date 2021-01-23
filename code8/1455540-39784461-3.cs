    public partial class Window1 : INotifyPropertyChanged {
    
        public Window1() {
          InitializeComponent();
          this._docs.Add(new Document { Name = "Doc1", Type = "docx", Description = "Important Doc", DocumentTypeName = "Word-Document" });
          this._docs.Add(new Document { Name = "Doc2", Type = "xlsx", Description = "Important Calculation", DocumentTypeName = "Excel-Document" });
          this._docs.Add(new Document { Name = "Doc3", Type = "pdf", Description = "Important Contract", DocumentTypeName = "Pdf-Document" });
          this.DataContext = this;
    
    
        }
    
        public Document SelectedDocument {
          get {
            return this._selectedDocument;
          }
          set {
            if (Equals(value, this._selectedDocument))
              return;
            this._selectedDocument = value;
            this.SubDocuments.Clear();
            this.SubDocuments.Add(value);
            this.OnPropertyChanged();
          }
        }
    
        public ObservableCollection<Document> SubDocuments
        {
          get { return this._subDocuments; }
          set
          {
            if (Equals(value, this._subDocuments)) return;
            this._subDocuments = value;
            this.OnPropertyChanged();
          }
        }
    
        private readonly ObservableCollection<Document> _docs = new ObservableCollection<Document>();
        private Document _selectedDocument;
        private ObservableCollection<Document> _subDocuments = new ObservableCollection<Document>();
        public ObservableCollection<Document> Documents => this._docs;
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
    
      }
