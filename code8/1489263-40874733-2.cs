    public class RayCast : MonoBehaviour
    {
        private RaycastHit hit;
    
        [SerializeField]
        private AudioSource source;
    
        [SerializeField]
        private AudioClip clip;
    
        //Refrence of Slider Canvas Script
        [SerializeField]
        private SliderSelect sliderCanvasScript;
    
    
    
        private void Update()
        {
            Debug.DrawRay(transform.position, transform.forward, Color.cyan);
            if (Input.GetKeyDown(KeyCode.A) && SliderSelect.check)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 9f))
                {
                    if (hit.collider.gameObject.name == "SliderCanvas")
                    {
                        Debug.Log("Ray cast to the slider");
                        StartCoroutine(doInOrder());
                    }
                }
            }
        }
    
        IEnumerator doInOrder()
        {
            //Wait for Fill to finish
            yield return StartCoroutine(sliderCanvasScript.FillUp());
            //Then Play Sound
            source.clip = clip;
            //Then Play Sound
            source.Play();
    
            //Wait for Audio to finish Playing
            while (source.isPlaying)
            {
                yield return null;
            }
            //Load new Scene
            SceneManager.LoadScene("Scene0", LoadSceneMode.Single);
        }
    }
