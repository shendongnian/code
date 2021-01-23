    bool isProcessing = true;
    private void switchControls(){
       isProcessing = true;
       //do work;
       isProcessing = false;
    }
    private void MyControl.OnEvent(object sender, EventArgs e){
       if(!isProcessing){
          //what you would normally do
       }
    }
