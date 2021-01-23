	using UnityEngine;
	public class Autof : MonoBehaviour {
		float fireDelay = 0f; // the delay between shots
		// Assume that the function below is your code to fire your weapon:
		void FireWeapon()
		{
			Debug.Log("Fire!!!");
		}
		// The function below activates the FireWeapon function
		void AutoFire(float fireRate)
		{
			if (fireDelay < fireRate)
			{
				fireDelay += Time.deltaTime;
			}
			if (fireDelay >= fireRate)
			{
				FireWeapon();
				fireDelay = 0f;
			}
		}
		void Update()
		{
			AutoFire(0.2f);
		}
	}
