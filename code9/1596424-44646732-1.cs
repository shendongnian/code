    private async Task RefreshStudentList()
    {
       //display progressbar
       _isProgressVisible = true;
       InvokeOnMainThread(() => RaisePropertyChanged(() => IsProgressVisible));
       // load data
       var data =  await _studentService.GetStudentAsync();
       Students = new ObservableCollection<StudentViewModel>
           (data.ConvertAll(x => new ClassViewModel(x)));
       //hide progressbar
       _isProgressVisible = false;
       InvokeOnMainThread(() => RaisePropertyChanged(() => IsProgressVisible));
    }
