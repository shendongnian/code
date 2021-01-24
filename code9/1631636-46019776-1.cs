    private static void HandleError(object sender, ErrorEventArgs e)
      {
           // Get the error message using 'e.ErrorContext.Error.Message'
           // e.ErrorContext.OriginalObject will give you the object/property that failed to deserialze
           e.ErrorContext.Handled = true;
      }
