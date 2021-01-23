        public interface IBindingObject
        {
           ControlBindingsCollection DataBinding {get;}   
        }
        
        public class MyButton : Button, IBindingObject
        {
           //Nothing to do here because the Button contains a DataBinding Property by default
        }
        
        public interface IView
        {
           IBindingObject WithdrawalButton {get;}
        }
    
        public class View : Form, IView
        {
          public IBindingObject WithdrawalButton {get {return new MyButton()}}
        }    
    
        public class Presenter
        {
            public Presenter(IView view, IModel model)
            {
               view.WithdrawalButton.DataBindings.Add(//do your binding);
            }
        }
