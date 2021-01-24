        private object _classmember;
        public object classmember
        {
            get { return _classmember; }
            set
            {
                _classmember = value;
                if (_classmember.GetType()==typeof(Boolean))
                {
                  //Do your stuff
                   MessageBox.Show("boolean");
                }
                if (_classmember.GetType() == typeof(int))
                {
                  //Do your stuff
                    MessageBox.Show("int");
                }
                if (_classmember.GetType() == typeof(double))
                {
                  //Do your stuff
                    MessageBox.Show("double");
                }
                  //Declare all the necessary datatypes like the above
            }
        }
