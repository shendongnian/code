    Person person = new Person();
    person.PropertyChanged += person_PropertyChanged;
    
      void person_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                var args = e as PropertyChangedExtendedEventArgs;
                //do what you want
            }
