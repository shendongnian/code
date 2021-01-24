    public class TextBoxValidator : ControlValidator<TextBox>
    {
         public TextBoxValidator(IEnumerable<TextBox> controls) : base(controls)
         {}
         public override bool ValidateControls()
         {
              foreach(TextBox tb in ControlsToValidate)
              {
                  if (tb.Text == "") // This validates the text cannot be empty
                  {
                      MessageBox.Show("Text cannot be empty");
                      tb.Focus();
                      return false;
                  }
              }
              return True;
         }
    }
