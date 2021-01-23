      public int CompareTo(object obj)
      {
            if (obj == null) return 1;
            Student other = obj as Student;
            if (other != null)
            {
                // Compare last names first, then by firstName
                int value = this.lastName.CompareTo(other.lastName);
                if (value == 0)
                    value = this.firstName.CompareTo(other.firstName);
                return value;
            }
            else
                throw new ArgumentException("Object is not a Student");
      }
