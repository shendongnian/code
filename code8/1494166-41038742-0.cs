    public ICommand ChangePageCommand
    {
        get
        {
            return new Command(
                    parameter => { this.ChangeViewModel(parameter as string); },
                    parameter =>
                        {
                            var str = parameter as string;
                            return !string.IsNullOrEmpty(str) && this.PageViewModels.ContainsKey(str);
                        });
        }
    }
    public void ChangeViewModel(string viewName)
    {
        this.CurrentPageViewModel = this.pageViewModels.FirstOrDefault(element => element.Key == viewName).Value;
    }
