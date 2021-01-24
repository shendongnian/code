    public ICommand ButtonCommand { get; private set; }
     
    public DemoViewModel ()
    {
        ...
        ButtonCommand = new Command (() => {
                var view = new LessonView();
                await Navigation.PushModalAsync(view);
            });
    }
