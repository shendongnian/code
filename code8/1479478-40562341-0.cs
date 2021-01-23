    public class HomeView : IHomeView
    {
       public string Text 
       {
          get {return richtextbox.Text;}
          set {richtextbox.Text = value;}
       }
    }
    public class HomePresenter
        {
            IHomeView view;
            IModel model;
            
            HomePresenter(IHomeView view, IModel model)
            {
               view = view;
               model = model;
               //Update View
               view.Text = model.Text;
            }
            
            public void UpdateModel
            {
               model.Text = view.Text; //Set the Model Property to value from Richtextbox
            }         
        }
    
        public class Model : IModel
        {
            public string Text {get;set} //Property which represent Data from Source like DB or XML etc.
        }
