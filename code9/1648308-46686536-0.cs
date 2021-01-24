    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class PlaneBombDroper : MonoBehaviour
    {
    public GameObject bomb;
    public GameObject bombDropPostion;
    public GameObject planePostion;
    int bombDropRandomNum;
    public float[] dropPostionsX;
    bool bombIsDroped;
    private bool launchingBomb = false;
    // Use this for initialization
    void Start()
    {
        bombDropRandomNum = Random.Range(1, 3);
    }
    void Update()
    {
        if (!launchingBomb)
        {
            if (bombDropRandomNum == 1 && bombIsDroped != true)
            {
                if (planePostion.transform.position.x < -2.75f && planePostion.transform.position.x > -3)
                {
                dropBomb();
                }
            }
            if (bombDropRandomNum == 2&& bombIsDroped != true)
            {
                if (planePostion.transform.position.x < -9.5 && planePostion.transform.position.x > -10)
                {
                    StartCoroutine("WaitForSeconds");
                    StopCoroutine("WaitForSeconds");
                }
            }
        }
        void dropBomb()
        {
            launchingBomb = true;
            Instantiate(bomb, gameObject.transform.position, gameObject.transform.rotation);
            launchingBomb = false;
        }
        IEnumerator WaitForSeconds()
        {
            launchingBomb = true;
            dropBomb();
            yield return new WaitForSeconds(1);
        }
    }
