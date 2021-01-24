    using UnityEngine;
    using System.Collections;
    public class cameraFollow : MonoBehaviour {
	public Transform player;
	public Transform player2;
	private bool idleFollow = true;
	private bool mountFollow = false;
	void Update ()
	{
		if (!mountFollow && idleFollow && Input.GetKeyDown (KeyCode.Space)) 
		{
			mountFollow = true;
			idleFollow = false;
			return;
		}
		if (mountFollow && !idleFollow && Input.GetKeyDown(KeyCode.Space))
		{
			idleFollow = true;
			mountFollow = false;
			return;
		}
		if (idleFollow && !mountFollow) 
		{
			transform.position = new Vector3 (player.position.x + .5f, player.position.y + .55f, -7.2f);
		}
		if (mountFollow && !idleFollow)
		{
			transform.position = new Vector3 (player2.position.x + .5f, player2.position.y + .55f, -7.2f);
		}
	}
}
