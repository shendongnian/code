	public class GlobalClass : MonoBehaviour
	{
		//static objects are not seen in inspector so we will asign player to public gameobject and inside script we transfer it to static gameobject so now we can get player gameobject with GlobalClass.player
		public static GameObject player;
		public GameObject _player;
		//With this you can set all other gameobjects like your GameController or something like that
		private void Start()
		{
			player = _player;
		}
	}
	public class CheckpointGeneration : MonoBehaviour
	{
		public GameObject checkpointPrefab;
		public float gap = 5.0f;
		public static int spawnedCheckpoints = 0; //You can alse set it as bool but with this you can maybe make to have 2 or more checkpoints
		private static Vector2 lastCheckpointPos = new Vector2(0, -2.35f);
		private void Start()
		{
			Instantiate(checkpointPrefab, lastCheckpointPos, checkpointPrefab.transform.rotation);
			spawnedCheckpoints++;
		}
		private void Update()
		{
			if (spawnedCheckpoints < 1)
			{
				SpawnCheckpoint();
			}
		}
		public static void RespawnAtCheckpoint()
		{
			if (CheckpointGeneration.spawnedCheckpoints > 0)
			{
				GlobalClass.player.transform.parent.position = CheckpointGeneration.lastCheckpointPos;
				GlobalClass.player.GetComponent<PlayerManager>().isDead = false;
				Camera.main.transform.position = GameObject.FindGameObjectWithTag("CameraFollow").transform.position;
				Debug.Log("Respawning...");
			} else
			{
				GameObject.FindGameObjectWithTag("GameController").GetComponent<ReloadLevel>().Reload();
			}
		} //Call this method when player die
		private static void SpawnCheckpoint()
		{
			Vector2 newCheckpointPos = new Vector2(lastCheckpointPos.x + gap, lastCheckpointPos.y);
			Instantiate(checkpointPrefab, newCheckpointPos, checkpointPrefab.transform.rotation); //Consider using Quaternion.identity
			lastCheckpointPos = newCheckpointPos;
			spawnedCheckpoints++;
		}
	}
	public class CheckpointController : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.tag == "Player")
			{
				CheckpointGeneration.spawnedCheckpoints--; //with this we sent message to your CheckpointGeneration script that this checkpoint is reached
				Debug.Log("Checkpoint Reached!");
				Destroy(gameObject);//When checkpoint is reached we destroy it and will spawn new one
			}
		}
	}
