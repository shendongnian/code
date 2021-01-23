    public class Form1: Form { // this should be already in your code... either form or webform
      public string[] LocationArray {get; set};
    
    
    public void button1_Click_1(object sender, EventArgs e)
        {
          this.LocationArray = ['a', 'b']; // or whatever variable
        }
    
     private void button1_Click(object sender, EventArgs e)
        {
        var array = this.LocationArray; // you do not need to create an extra variable, this is only a way to reference it
        }
    }
