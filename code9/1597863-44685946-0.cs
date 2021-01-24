    private void OnCharacterPosition(int cnnId, float x, float y, float z, float rx, float ry, float rz)
    {
        Quaternion characterRotation = Quaternion.Euler(rx,ry,rz);
        Debug.Log("Character rotation: " + characterRotation);
        clients.Find(c => c.connectionId == cnnId).playerPosition = new Vector3(x, y, z);
        //clients.Find(c => c.connectionId == cnnId).playerRotation = Quaternion.Euler(new Vector3(0, 30, 0));
    }
