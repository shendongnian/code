    void Update()
        {
            if (isLocalPlayer)
            {
                if (Input.GetButton("Fire1"))
                {
                    Vector3 FiringSpot = new Vector3(PlayerCam.transform.position.x, PlayerCam.transform.position.y, PlayerCam.transform.position.z);
                    Vector3 FireDirection = PlayerCam.transform.forward;
                    CmdFire(FiringSpot, FireDirection);
                }
    
        [Command]
        void CmdFire(Vector3 firingPoint, Vector3 FiringDirection)
        {
            Ray shooterRay = new Ray(firingPoint, FiringDirection);
            if (Physics.Raycast(shooterRay, out Hit, 10000))
            {
                GameObject Bullet_Hole = (GameObject)Instantiate(bullet_Hole_Prefab, Hit.point, Quaternion.FromToRotation(Vector3.up, Hit.point));
                NetworkServer.Spawn(Bullet_Hole);
                Destroy(Bullet_Hole, 10);
            }
        }
