    public abstract class ControlValidator<T> where T : Control
    {
         protected List<T> ControlsToValidate;
         public ControlValidator(IEnumerable<T> controls)
         {
              this.ControlsToValidate = new List<T>(controls);
         }
         public abstract bool ValidateControls();
    }
