     using UnityEngine;
        using UnityEngine.UI;
        public class SliderScript : MonoBehaviour {
    
        private double sf;
        private ParticleSystem ps;
    	// Use this for initialization
    	void Start () {
            
    	}
    	
    	// Update is called once per frame
    	void Update () {
            sf = GameObject.Find("Slider").GetComponent<Slider>().value;
            ps = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
            var main = ps.main;
            main.gravityModifier = (float)sf;
            print(sf );
        }
    }
