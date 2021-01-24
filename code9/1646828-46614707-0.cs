    public **abstract** class ToolScript : MonoBehaviour {
        public void isActive()
        {
            if (Input.GetKeyDown("space"))
            {
                Use();
            }
        }
        **public abstract void** Use();
    }
    
    public class GunController : ToolScript
    {
        public **override** void Use()
        {
          //Spawn bullet at this direction, this speed, give it spiral, tons of behavior etc. etc.
        }
        private void Update()
        {
          isActive();
        }
    }
    
    public class FlamethrowerController : ToolScript
    {
        public **override** void Use()
        {
          //Spawn fire at this direction, this speed, set tip of flamethrower to be red etc etc
        }
        private void Update()
        {
          isActive();
        }
    }
