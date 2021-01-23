    using (var en = widgets.GetEnumerator())
    {
      if (en.MoveNext())
      {
        do
        {
          var widget = en.Current;
          // process widget.
        } while (en.MoveNext());
      }
      else
      {
        // Handle empty.
      }
    }
