	public class EnemyMovement : MonoBehaviour {
		//target
		public Transform Player;
		//the distace the enemy will begin walking towards the player
		public float walkingDistance = 10.0f;
		//the speed it will take the enemy to move
		public float speed = 10.0f;
		private Vector3 Velocity = Vector3.zero;
		void Start(){
		}
		void Update(){
			transform.LookAt (Player);
			Vector3 goto = Player.position;
			goto.y = transform.position.y;
			//finding the distance between the enemy and the player
			float distance = Vector3.Distance(transform.position, goto);
			if(distance < walkingDistance){
			//moving the enemy towards the player
			transform.position = Vector3.SmoothDamp(transform.position, 
			goto, ref Velocity, speed);
		}
	}
