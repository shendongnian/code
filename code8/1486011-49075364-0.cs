        private void errorDTOOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (!string.Equals(propertyChangedEventArgs.PropertyName, nameof(dto.HasError))) return;
                OnPropertyChanged(() => ErrorMessages);
        }
        public List<string> ErrorMessages => getErrorMessages();
        private List<string> getErrorMessages() {
            //create list in a manner of your choosing
        }
