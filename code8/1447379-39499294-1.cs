    public class GameModel : Model
    {
        public int ID { get; set; }
    }
    public class GameView : View<GameModel, GameView>
    {
        public float FOV { get; set; }
    }
    public class GameController : GameView.BaseControler
    {
        // Set ID
        public GameController()
        {
            Model.ID=100;
            View.FOV=45f;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var gm = new GameModel();
            var view = new GameView();
            var ctrl = new GameController();
            view.Connect(gm, ctrl);
            Debug.WriteLine(view.Model.ID);
        }
    }
----------
    public class Model
    {
        
    }
    public class View<TModel,TView> where TModel : Model where TView : View<TModel, TView>
    {
        public TModel Model { get; private set; }
        public BaseControler Controler { get; private set; }
        public void Connect(TModel model, BaseControler controler)
        {
            this.Model=model;
            this.Controler=controler;
            this.Controler.Connect(model, this as TView);
        }
        public class BaseControler
        {
            public TView View { get; private set; }
            public TModel Model { get; private set; }
            public void Connect(TModel model, TView view)
            {
                this.Model=model;
                this.View=view;
            }
        }
    }
