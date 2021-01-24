    public class StateManager
    {
        private ContentManager Content { get; set; }
        private Game1 Game { get; set; }
        private Stack<Scene> sceneStack = new Stack<Scene>();
        private GameState currentScene;
        private GameState previousScene;
        public StateManager(ContentManager content, Game1 game)
        {
            // Pretty common to pass one or both of these instances around in your code.
            this.Game = game;
            this.Content = content;
        }
        public void AddScene(GameState newScene)
        {
            // This is the crucial part. We are saving the state of the old scene.
            if (currentScene != null)
                this.previousScene = currentScene;
            sceneStack.Push(newScene); // New scene is stacked 'on top' of the old one
            this.currentScene = newScene;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // Out in Game1.cs we are calling this method from within
            // its own Draw() method.
            this.currentScene.Draw(spriteBatch);
        }
    }
    public class Scene : GameState
    {
        // Any state information needed for your scene like menus, terrain, etc
    }
    
    public abstract class GameState
    {
        // The base class for your Scenes which contains code relevant to all scene types.
        // You could go a step further and make an interface as well.
    
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // Logic to draw the game state. Textures, sprites, text, child
            // elements contained inside this state, etc.
        }
    }
