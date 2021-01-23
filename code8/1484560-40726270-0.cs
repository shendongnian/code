    private void Close(DialogResult result) {
      if (ContainingForm != null) {
        ContainingForm.DialogResult = result;
        ContainingForm.Close();
        ContainingForm.Dispose();
      }
    }
