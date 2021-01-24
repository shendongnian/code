        <i:Interaction.Triggers>
            <ei:KeyTrigger Key="Escape">
                <i:InvokeCommandAction Command="{Binding KeyDownCommand}" />
            </ei:KeyTrigger>
        </i:Interaction.Triggers>
 
    public ICommand KeyDownCommand
        {
            get { return new RelayCommand(KeyboardKeyDownCommand, true); }
        }
        private void KeyboardKeyDownCommand()
        {
       		///code
        }
