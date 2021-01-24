    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap myImage = LoadFromDisk();
            videoSource_New(sender,ref myImage);
        }
    
         private void videoSource_New( object sender, ref Bitmap image )
         {
             //some logic to make changes in image object or use the image object.
         }
    }
