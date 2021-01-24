    public ICommand ButtonCommand { get; private set; }
    public ICommand GoLeftCommand { get; private set; }     
    public ICommand GoRightCommand { get; private set; }     
    public DemoViewModel ()
    {
        ...
        ButtonCommand = new Command (() => {
                var view = new LessonView();
                await Navigation.PushModalAsync(view);
            });
        GoLeftCommand = new Command (() => {
                var view = new LeftView();
                await Navigation.PushModalAsync(view);
            });
        GoRightCommand = new Command (() => {
                var view = new RightView();
                await Navigation.PushModalAsync(view);
            });
    }
