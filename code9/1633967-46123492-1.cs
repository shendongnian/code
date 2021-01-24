    using UnityEngine;
    using System.Collections;
 
    public class TriggerSpinControl : MonoBehaviour
    {
		public float speed1 = 25f;
		public float speed2 = 100f;
	 
		private void Update()
		{
			transform.Rotate(Vector3.forward, speed2 * Time.deltaTime);
		}
	 
		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == "MainCamera")
			{
				enabled = false;
			}
		}
	 
		void OnTriggerStay(Collider other)
		{
			if (other.tag == "MainCamera")
	 
			{
	 
				transform.Rotate(Vector3.forward, speed1 * Time.deltaTime);
			}
		}
	 
		private void OnTriggerExit(Collider other)
		{
			if (other.tag == "MainCamera")
			{
	 
				enabled = true;
			}
		}
    }
