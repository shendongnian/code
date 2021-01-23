      public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Studentother = obj as Student;
            if (other != null)
            {
                int value = this.lastName.CompareTo(other.lastName);//compare last names first, then by firstName
                if (value == 0)
                    value = this.firstName.CompareTo(other.firstName);
                return value;
            }
            else
                throw new ArgumentException("Object is not a Student");
        }
