      protected override void InsertItem(int index, string item, bool _cancel)
      {
        base.InsertItem(index, item);
        if (!_cancel)
        {
          //Do some stuff
        }
      }
