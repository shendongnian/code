       private TheCollection yourcollection;
      public TheCollection Yourcollection{
            get{
                yourcollection.CollectionChanged -= Your_CollectionChanged;
                // use sort-Extension to sort pointprofil
                yourcollection.Sort();
                // read CollectionChange-Event
                yourcollection.CollectionChanged += Your_CollectionChanged;
                return yourCollection;
            }
    }
