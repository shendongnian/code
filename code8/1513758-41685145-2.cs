    private void Update()
    {
        bool keyDown = Input.GetKeyDown(KeyCode.Keypad0);
        if (keyDown)
        {
            Client[] array = UnityEngine.Object.FindObjectsOfType<Client>();
            Vector3 vector1 = new Vector3(1.0f, 1.0f, 1.0f);
            Vector3 vector2 = new Vector3(1.0f, 1.0f, 1.0f);
            Vector3 vector3 = new Vector3(1.0f, 1.0f, 1.0f);
            Vector3 vector4 = new Vector3(1.0f, 1.0f, 1.0f);
            for (int i = 0; i < array.Length; i++)
            {
                Client client = array[i];
                client.send_createent(vector1,vector2,vector3,vector4, 10);
    
            }
        }
