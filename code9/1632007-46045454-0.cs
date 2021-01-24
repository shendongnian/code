    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap myImage = LoadFromDisk();
            videoSource_New(sender,myImage);
        }
    
         private void videoSource_New( object sender, ref Bitmap image )
         {
             //some logic
         }
    }
