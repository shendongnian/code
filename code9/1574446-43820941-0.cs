        void ReplaceCamera(Transform player = null)
        {
            Camera.main.transform.SetParent(player);
        }
    // Usage Examples
        ReplaceCamera(); // will send it to the root
        ReplaceCamera(player); // will send it to be part of the player again.
