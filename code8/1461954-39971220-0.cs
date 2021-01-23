     public class MyClassEvent
     {
         public static void OnClick(object sender, EventArgs e)
         {
            Button mybotton = sender as Button;
             Form myform = mybotton.Parent as Form; //If button is directly onform     
         }
        
     }
