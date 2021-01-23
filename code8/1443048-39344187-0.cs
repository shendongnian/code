    using UnityEngine;
    using System.Collections;
    
    public class Clicker
    {
        public bool clicked()
        {
            return Input.anyKeyDown;
        }
    }
