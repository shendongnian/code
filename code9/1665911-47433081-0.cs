    private ICommand TransitionCommand
    {
        get
        {
            bool isExecuting = false;
            return new Command(async () =>
            {
                if(isExecuting) return;
                isExecuting = true
                try
                {
                    this.AnchorX = 0.48;
                    this.AnchorY = 0.48;
                    await this.ScaleTo(MAGNIFICATION_VALUE, 50, Easing.Linear);
                    await Task.Delay(ANIMATED_TIME);
                    await this.ScaleTo(INITIAL_VALUE, 50, Easing.Linear);
                    if (Command != null)
                    {
                        Command.Execute(CommandParameter);
                    }
                 }
                 finally 
                 {
                      isExecuting = false;
                 }
            });
        }
    }
