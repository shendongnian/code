     public ICommand DeleteEintragCommand
            {
                get
                {
                    return new Command((e) =>
                        {
                            var item = (e as MyModelObject);
                            // delete logic on item
                        });
                }
            }
