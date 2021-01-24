    private void MyTextBoxPreviewMouseDown(object sender, MouseButtonEventArgs e){
      if (e.ClickCount == 3) {
        MyTexBox.SelectAll();
      }
    }
