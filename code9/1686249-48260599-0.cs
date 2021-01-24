    public class EnemySetAlpha : MonoBehaviour {
    
        public float fadeSpeed = 0.1f;
        private Material[] enemyMaterials;
        // Value used to know when the enemy has been spawned
        private float spawnTime ;
    
        // Use this for initialization
        void Start () {
            // Retrieve all the materials attached to the renderer
            enemyMaterials = GetComponent<SkinnedMeshRenderer> ().materials;
            spawnTime = Time.time ;
        }
    
        // Update is called once per frame
        void Update () {
                // Set the alpha according to the current time and the time the object has spawned
                SetAlpha( (Time.time - spawnTime) * fadeSpeed );
        }
    
        void SetAlpha(float alpha)
        {
            // Change the alpha value of each materials' color
            for( int i = 0 ; i < enemyMaterials.Length ; ++i )
            {
                Color color = enemyMaterials[i].color;
                color.a = Mathf.Clamp( alpha, 0, 1 );
                enemyMaterials[i].color = color;
            }
        }
    }
