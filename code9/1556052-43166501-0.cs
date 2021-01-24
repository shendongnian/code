        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                if (id > 0 ) {
                    vmEr = new vmReceipt(id);
                    this.DataContext = vmEr;
                }
            }
        }
