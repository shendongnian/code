    public partial class Form1 : Form
    {
       private async void button1_Click(object sender, EventArgs e) 
       {
          BaseClass wpSec = new BaseClass();
          CWClient client = await Task.Run(() =>
              {
                  return wpSec.ClientFileContext(selectedFileFullPath, true);
              }
          );
          var whyAreYouNotWorking = "Stop";
       }
    }
