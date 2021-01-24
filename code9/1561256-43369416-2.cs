     private void Submit_Clicked(object sender, System.EventArgs e)
     {
        var text = _urlEntry?.Text;
    
        if(text.Length > 0)
        {
           _model = new Model {  BaseAddress = text };
           MakeRequest(_model.WebServiceURL);
        }
        else
        {
            DisplayAlert("Error", "Entry field is empty", "ok");
        }
      }
