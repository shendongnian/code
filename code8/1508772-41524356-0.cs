    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class movement : MonoBehaviour
    {
        public GameObject position1;
        public GameObject position2;
        public GameObject position3;
        public GameObject position4;
        public GameObject position5;
        public GameObject position6;
        public int PressedTime;
        public float speed = 30;
    void Update()
    {
		if (Input.GetKeyDown("space"))
		{
			PressedTime += 1;
			if (PressedTime == 1)
			{
				transform.position = Vector3.MoveTowards(transform.position, position1.transform.position, speed);
			}
			if (PressedTime == 2)
			{
				transform.position = Vector3.MoveTowards(transform.position, position2.transform.position, speed);
			}
			if (PressedTime == 3)
			{
				transform.position = Vector3.MoveTowards(transform.position, position3.transform.position, speed);
			}
			if (PressedTime == 4)
			{
				transform.position = Vector3.MoveTowards(transform.position, position4.transform.position, speed);
			}
			if (PressedTime == 5)
			{
				transform.position = Vector3.MoveTowards(transform.position, position5.transform.position, speed);
			}
			if (PressedTime == 6)
			{
				GetComponent<Rigidbody>().AddForce(position6.transform.position * speed);
			}
			
		}       
    }
    }
