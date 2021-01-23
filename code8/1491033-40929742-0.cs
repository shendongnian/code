    using UnityEngine;
    using System.Collections;
	public class destroywall : MonoBehaviour
	{
		                //Alternate sprite to display after Wall has been attacked by player.
		public static int hp = 4;                          //hit points for the wall.
		public static int hpx = 0;
	void  OnTriggerEnter (  Collider other   ){
		if (other.tag == "destroywall") {
			if (hp == hpx) {
				Destroy (other.gameObject);
			}
		}
	}
			 
    }
