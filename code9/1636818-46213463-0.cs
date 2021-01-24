    using System;
    using System.Collections.Generic;
    using UnityEngine;
    
    [System.Serializable]
    public class Turret
    {
        public int ammo;
        public int maxAmmo;
        public float reloadTime;
        
        public void Shoot()
        {
            // Do some shooting stuff!
        }
    }
    
    public class Player : MonoBehaviour
    {
        public Turret[] turretTypes;
        public Turret currentTurret;
        
        int currentTurretIndex = 0;
        
        void Start()
        {
            currentTurret = turretTypes[currentTurretIndex];
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Do your turret switching here.
                // For now I've just increased the turret index by 1.
                currentTurretIndex++;
                currentTurret = turretTypes[currentTurretIndex]
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                currentTurret.Shoot();
            }
        }        
    }
