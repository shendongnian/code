    class Job
      {
            public int Key { get; set; }
            public string Description { get; set; }
            public override string ToString()
            {
                return String.Format("№{0} - ({1})", this.Key, this.Description);
            }
      }
