    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class SpriteCColor : MonoBehaviour {
    public Material[] materials;
    public Renderer rendBlock;
    public int index = 1;
	// Use this for initialization
	void Start () {
        rendBlock = GetComponent<Renderer>();
        rendBlock.material.SetColor(5, Color.red);
    }
    // Update is called once per frame
    void Update () {
       /*
        when index = 
        1 = red
        2 = yellow
        3 = green
        4 = blue
    */
        if (Input.GetMouseButtonDown(0)) { 
            index += 1;
            if (index == materials.Length +1) {
                index = 1;
            }
            //print(index);
            if (index == 1)
            {
                rendBlock.material.SetColor(5, Color.red);
            }
            if (index == 2)
            {
                rendBlock.material.SetColor(5, Color.yellow);
            }
            if (index == 3)
            {
                rendBlock.material.SetColor(5, Color.green);
            }
            if (index == 4)
            {
                rendBlock.material.SetColor(5, Color.blue);
            }
            }
            } 
            }
