    public class AudioManagerScript : MonoBehaviour
    {
         public Transform[] points;
         public AudioClip[] clips;
         public float volume = 0.9f;
         void Start()
         {
             InvokeRepeating("PlaySoundAtRandomPosition", 1.0f, 1.0f);
         }
         void PlaySoundAtRandomPosition()
         {
             // Take random position
             int rndPosIdx = Random.Range(0, points.Length);
             // Take random clip
             int rndClipIdx = Random.Range(0, clips.Length);
             AudioSource.PlayClipAtPoint(clips[rndClipIdx], points[rndPosIdx].position, volume);
         }
    }
