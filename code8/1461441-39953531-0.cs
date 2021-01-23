       //try this
       protected void Page_Load(object sender, EventArgs e)
       {
        if (!IsPostBack)
        {
            cart_number("1");
        }
       }
    private static int i;
    private void cart_number(string flag)
    {
        if(flag!="1"){
        i=0;
        if(i>=0){
        lbl_cart_number.Text =( i+1).ToString();
         }
        }
 
      }
      protected void Button1_Click(object sender, EventArgs e)
       {
        cart_number();
       }
