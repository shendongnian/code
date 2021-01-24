        float speed = 0.4f; // Speed
        float amplitude = 70; // How far can it swing?
    
        private void Update()
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Sin(Time.timeSinceLevelLoad * Mathf.PI * speed) * amplitude)); // Swing
        }
