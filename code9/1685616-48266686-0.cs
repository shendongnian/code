    string _viewModelText;
        public string ViewModelText
        {
            get { return _viewModelText; }
            set
            {
                _viewModelText = value;
                if (_viewModelText != null)
                {
                    MyTextView.Text = _viewModelText;
                }
            }
        }
        this.CreateBinding(this).For(v => v.ViewModelText).To<MyViewModel>(vm => vm.QuestionText).OneWay().Apply();
