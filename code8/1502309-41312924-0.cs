    using UnityEngine;
    public class RotateScript : MonoBehaviour
    {
    float speed = 100f;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.RotateAround(this.transform.position, new Vector3(1, 0, 0), speed * Time.deltaTime);
        }
        if (Input.GetKey("down"))
        {
            transform.RotateAround(this.transform.position, new Vector3(-1, 0, 0), speed * Time.deltaTime);
        }
        if (Input.GetKey("left"))
        {
            transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), speed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.RotateAround(this.transform.position, new Vector3(0, -1, 0), speed * Time.deltaTime);
        }
    }
    }
