        #region Commands
        public DelegateCommand<IClosable> CloseCommand => new DelegateCommand<IClosable>(Close, CanClose);
        private bool CanClose(IClosable parameter)
        {
            return true;
        }
        private void Close(IClosable parameter)
        {
            var closable = parameter as IClosable;
            if (closable != null)
            {
                closable.Close();
            }
        }
