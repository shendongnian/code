                   delegate void submitdelegate();
                    public partial class Form1 : Form
                      {
                       public Form1()
                            {
                              InitializeComponent();
                             }
                       IAsyncResult ia;
                  private void Form1_Load(object sender, EventArgs e)
                    {
                    submitdelegate sd=Submit;
                  ia=sd.BeginInvoke(()=>{},null,null);
           
                     }
                     private void Submit()
                    {
  
                       }
      
        void button_Click(object sender, EventArgs e)
        {
          if(ia.IsCompleted)
           {//run all the things you want here
              }
            }
