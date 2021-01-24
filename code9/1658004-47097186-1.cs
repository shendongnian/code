    public class CollisionDispatch : MonoBehaviour
    {
        public void RegisterCollision(Fruit obj, BaseCollider collider, Collision collision)
        {
            obj.Dispatch(collider, collision);
        }
    }
    public interface ICollisionableFruit
    {
        //add method for each collision type
        void HandleNetCollision(Collision collision);
        void HandleElseCollision(Collision collision);
    }
    public abstract class Fruit : ICollisionableFruit
    {
        public virtual void Dispatch(BaseCollider collider, Collision collision)
        {
            collider.HandleCollision(this, collision);
        }
        //declare all of interface's methods as abstract
        public abstract void HandleNetCollision(Collision collision);
        public abstract void HandleElseCollision(Collision collision);
    }
    public class Banana : Fruit
    {
        //override all methods
        public override void HandleNetCollision(Collision collision)
        {
            Debug.LogFormat("HandleNetCollision for {0}", this.GetType());
        }
        public override void HandleElseCollision(Collision collision)
        {
            Debug.LogFormat("HandleElseCollision for {0}", this.GetType());
        }
    }
    public abstract class BaseCollider
    {
        CollisionDispatch dispatch;
        void OnCollisionEnter(Collision coll)
        {
            var obj = coll.gameObject.GetComponent<Fruit>();
            dispatch.RegisterCollision(obj, this, coll);
        }
        public abstract void HandleCollision(ICollisionableFruit fruit, Collision collision);
    }
    public class NetCollision : BaseCollider
    {
        public override void HandleCollision(ICollisionableFruit fruit, Collision collision)
        {
            Debug.LogFormat("NetCollision HandleCollision");
            fruit.HandleNetCollision(collision);
        }
    }
    public class ElseCollision : BaseCollider
    {
        public override void HandleCollision(ICollisionableFruit fruit, Collision collision)
        {
            Debug.LogFormat("NetCollision HandleCollision");
            fruit.HandleElseCollision(collision);
        }
    }
