    public abstract class Fruit
    {
        public abstract void Dispatch(BaseCollider collider, Collision collision);
    }
    public class Banana : Fruit
    {
        public override void Dispatch(BaseCollider collider, Collision collision)
        {
            collider.HandleCollision(this, collision);
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
        public abstract void HandleCollision<TFruit>(TFruit fruit, Collision collision)
            where TFruit : Fruit;
    }
    public class NetCollision : BaseCollider
    {
        public override void HandleCollision<TFruit>(TFruit fruit, Collision collision)
        {
            Debug.LogFormat("NetCollision HandleCollision");
        }
    }
    public class ElseCollision : BaseCollider
    {
        public override void HandleCollision<TFruit>(TFruit fruit, Collision collision)
        {
            Debug.LogFormat("NetCollision HandleCollision");
        }
    }
    public class CollisionDispatch : MonoBehaviour
    {
        public void RegisterCollision(Fruit obj, BaseCollider collider, Collision collision)
        {
            obj.Dispatch(collider, collision);
        }
    }
