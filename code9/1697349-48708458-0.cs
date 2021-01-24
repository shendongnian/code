    public interface ICollidableObject
    {
        void CollidedWith(ICollidableObject other);
    }
    public class CollidableBlock : MonoBehaviour, ICollidableObject
    {
        public void CollidedWith(ICollidableObject other)
        {
            Debug.Log((other as MonoBehaviour).gameObject.name);
        }
    }
    public class CollidableSphere : MonoBehaviour, ICollidableObject
    {
        public void CollidedWith(ICollidableObject other)
        {
            Debug.Log("sphere001");
        }
    }
