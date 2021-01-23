    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class NumberWizard : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {
            print("Welcome to Number Wizard!");
            print("Pick a number in your head, but don't tell me!");
            int max = 100000, min = 1;
            print("Choose a number between " + min + " and " + max + ".");
            print( Random.Range(min,max));
        }
        // Update is called once per frame
        void Update()
        {
        }
    }
