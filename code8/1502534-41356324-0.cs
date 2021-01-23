     using UnityEngine;
    using System.Collections;
    [RequireComponent(typeof(AudioSource))]
    public class colisaoPicos : MonoBehaviour {
    
    
    
    Manager gameManager;
        public AudioClip impact;
        private AudioSource audio;
    void Start()
    {
    audio=GetComponent<AudioSource>();
        gameManager = GameObject.Find ("GameController").GetComponent<Manager();
    }
    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player") {
       
    audio.PlayOneShoot(impact);
            gameManager.LifeDown();
        }
    }
}
