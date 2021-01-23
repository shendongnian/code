    private void Update()
    {
        bool keyDown = Input.GetKeyDown(KeyCode.Keypad0);
        if (keyDown)
        {
            Client[] array = UnityEngine.Object.FindObjectsOfType<Client>();
            Vector vector1 = new Vector(1.0f, 1.0f, 1.0f);
            Vector vector2 = new Vector(1.0f, 1.0f, 1.0f);
            Vector vector3 = new Vector(1.0f, 1.0f, 1.0f);
            Vector vector4 = new Vector(1.0f, 1.0f, 1.0f);
            for (int i = 0; i < array.Length; i++)
            {
                Client client = array[i];
                client.send_createent(vector1,vector2,vector3,vector4, 10);
    
            }
        }
