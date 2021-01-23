     interface IGKComponentSystem<out T> 
     {
     }
     class GKComponentSystem<T> : IGKComponentSystem
     {
     }
     List<IGKComponentSystem<GKComponent>> _systems = new List<IGKComponentSystem<GKComponent>(); 
     // Should work from there...  
     public void AddSystem<T>(int position = -1) where T : GKComponent
     {
        var system = new GKComponentSystem<T>();
        _systems.Add(system);
     }
