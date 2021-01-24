    public class MyButton : Button
        {
            public override void NotifyDefault(bool value)
            {
                if (this.IsDefault != value)
                {
                    this.IsDefault = value;
                }
    
                if (IsDefault)
                {
                    this.BackColor = Color.Red;
                }
                else
                {
                    this.BackColor = Color.Green;
                }
            }
        }
