    public class spn2 : MonoBehaviour {
    	//variables here that I removed
    	//removed start method
    
        // Update is called once per frame
        void  Update()
        {
            this.spawnTimer -= Time.deltaTime;
            if(this.spawnTimer<=0.0f)
            {
                //instantiation stuff;
                {
                case 0:
    				Instantiate(Resources.Load(Enemy) as GameObject, spawnPos, spawnRot);
                    break;
                case 1:
                    Instantiate(MediumEnemey, spawnPos, spawnRot);
                    break;
                case 2:
    				//instantiation logic
                    break;
                }
                this.spawnTimer = this.TimeBetweenSpawns;
    			
            Destroy (gameObject, .7f);  <-- Destroy is here? This is your problem!
            }
    
        }
    
    }
