    public class SimpleParticle : MonoBehaviour
    {
        public float Duration, Distance, Speed, traveledDistance, birth;
        public Vector3 Direction, Size;
    
        public static Action<SimpleParticle> ConstructorGenerator(float duration, float distance, Vector3 size, float speed, Vector3 direction)
        {
            return (self) => {
                self.Duration = duration;
                self.Distance = distance;
                self.Size = size;
                self.Direction = direction;
                self.Speed = speed;
                self.Init();
            };
        }
    
        void Init()
        {
            birth = Time.time;
            transform.localScale = Size;
        }
    
        void Update()
        {
            float deltaDist =  Speed * Time.deltaTime;
            traveledDistance += deltaDist;
            transform.position += Direction * deltaDist;
    
            if(Time.time - birth > Duration)
                Destroy(this.gameObject);
        }
    }
