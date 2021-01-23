    public class Spawn: MonoBehaviour{
        public boolean endgame = false;
        GameObject nemico = Instantiate(Enemy);
        nemico.ParentSpawn = this
    }
    public class Enemy: MonoBehaviour{
        public Spawn spawn;
        void OnTriggerEnter(Collider other){
            if (other.tag == "Finish"){
                Spawn.endGame = true;
            }
        }
    }
