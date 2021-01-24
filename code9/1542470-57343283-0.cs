        public DateTime DateStarted
        {
            get
            {
                //SET
                if (this.EmployeeJobAssignments == null)
                    this.EmployeeJobAssignments = new EmployeeJobAssignments();
                return this.EmployeeJobAssignments.DateStarted;
            }
            set { this.EmployeeJobAssignments.DateStarted = value;
                base.RaisePropertyChanged("DateStarted");
            }
        }
