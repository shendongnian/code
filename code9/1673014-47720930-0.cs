                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;
                
                public class cubecolor : MonoBehaviour {
                    private bool isGreen = false; /*Let's create a boolean to store if the cube  
                    is green or red*/
                    
                
                    // Use this for initialization
                    void Start () {
                        gameObject.GetComponent<Renderer> ().material.color = Color.red;
                    }
                
                    // Update is called once per frame
                    void Update () {
                        if (Input.GetKey(KeyCode.C){
                            if(isGreen){ //Check if the color is green
                                gameObject.GetComponent<Renderer> ().material.color = Color.red;
                            }else{
                                gameObject.GetComponent<Renderer> ().material.color = Color.green;
                            }
                            isGreen = !isGreen; //Switch the boolean.
                        }
                }
