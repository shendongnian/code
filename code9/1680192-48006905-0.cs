    namespace testApp
    {
        public class testclass : IDisposable
        {
           
           public void welcome()
           {
             //some code goes here
           }
        }
     }
    private void button1_Click(object sender, EventArgs e)
    {
           using (var obj = new testclass())
           {
           }
     } 
