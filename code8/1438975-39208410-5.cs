    public class MyForm: FormBase
    {
        protected override void OnKeyPress(KeyEventArgs e)
        {
            if(KeyDown(Keys.A))
            {
                //do something when 'A' is pressed
            }
            else if (KeyDown(Keys.B))
            {
                //do something when 'B' is pressed
            }
            else
            {
                //something else
            }
        }
    }
