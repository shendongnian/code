    public class EnemySetAlpha : MonoBehaviour {
    
        public Material enemyMaterial;
        public float fadeSpeed = 0.1f;
        // Value used to know when the enemy has been spawned
        private float spawnTime ;
    
        // Use this for initialization
        void Start () {
            // Because `Material` is a class,
            // The following line does not create a copy of the material
            // But creates a reference (points to) the material of the renderer
            enemyMaterial = GetComponent<SkinnedMeshRenderer> ().material;
            spawnTime = Time.time ;
        }
    
        // Update is called once per frame
        void Update () {
                // Set the alpha according to the current time and the time the object has spawned
                SetAlpha( (Time.time - spawnTime) * fadeSpeed );
        }
    
        void SetAlpha(float alpha)
        {
            // Here you assign a color to the referenced material,
            // changing the color of your renderer
            Color color = enemyMaterial.color;
            color.a = Mathf.Clamp( alpha, 0, 1 );
            enemyMaterial.color = color;
        }
    }
