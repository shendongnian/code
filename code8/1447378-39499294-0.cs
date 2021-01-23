    public class Model
    {
        
    }
    public class View<TModel,TView> where TModel : Model where TView : View<TModel, TView>
    {
        public TModel Model { get; protected set; }
        public Controler<TModel, TView> Controler { get; protected set; }
        public void Connect(TModel model, Controler<TModel, TView> controler)
        {
            this.Model=model;
            this.Controler=controler;
            controler.View=this as TView;
            controler.Model=model;
        }
    }
    public class Controler<TModel, TView> where TModel: Model where TView : View<TModel, TView>
    {
        public TView View { get; internal set; }
        public TModel Model { get; internal set; }
    }
    public class GameModel : Model
    {
        public int ID { get; set; }
    }
    public class GameView : View<GameModel, GameView>
    {
    }
    public class GameController : Controler<GameModel, GameView>
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            var gm = new GameModel() { ID=1000 };
            var view = new GameView();
            var ctrl = new GameController();
            view.Connect(gm, ctrl);
            Debug.WriteLine(view.Model.ID);
            // have access to the derived model and view
        }
    }
