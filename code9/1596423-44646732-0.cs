    private async Task RefreshStudentList()
    {
       //display progressbar
       _isProgressVisible = true;
       InvokeOnMainThread(() => RaisePropertyChanged(() => IsProgressVisible));
       // load data
       var task =  _studentService.GetStudentAsync();
       await task;
       Students = new ObservableCollection<StudentViewModel>
           (task.Result.ConvertAll(x => new ClassViewModel(x)));
       //hide progressbar
       _isProgressVisible = false;
       InvokeOnMainThread(() => RaisePropertyChanged(() => IsProgressVisible));
    }
