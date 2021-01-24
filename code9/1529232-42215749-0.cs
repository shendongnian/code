        public ObservableCollection<Subject> SubjectList
        {
            set { base.SetValue(SubjectListProperty, value); }
            get { return (ObservableCollection<Subject>)base.GetValue(SubjectListProperty); }
        }
