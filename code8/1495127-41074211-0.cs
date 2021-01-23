    public ICommand OpenDialogFile
        {
            get
            {
                return new Prism.Commands.DelegateCommand<RichEditBox>(OpenDialogToAttach);
            }
        }
