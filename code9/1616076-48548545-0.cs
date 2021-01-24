    public class GameObject
    {
        List<GameObjectComponent> _goComponent = new List<GameObjectComponent();
        
        public T GetComponent<T>() where T : GameObjectComponent
        {
            foreach (GameObjectComponent goc in _goComponent)
                if (goc.GetType().Equals(typeof(T)))
                    return (T)goc;
            return null;
        }
        public void AddComponent(GameObjectComponent gameObjectComponent)
        {
            _goComponent.Add(gameObjectComponent);
            gameObjectComponent.gameObject = this;
            gameObjectComponent.Init();
        }
        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObjectComponent _goc in _goComponent)
                _goc.Update(gameTime);
        }
        public static void Instantiate(GameObject gameObject)
        {
           Scene._AddedGO.Add(gameObject);
        }
        public static void Destroy(GameObject gameObject)
        {
           Scene._RemoveGO.Add(gameObject);
        }
        
    }
