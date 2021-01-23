        foreach (GameObject g in allGameObjectsInCurrentScene)
        {
            MonoBehaviour m = g.GetComponent<MonoBehaviour>();
            if (m.GetType().GetMethod("Update") != null)
                m.Invoke("Update");
        }
        // Additional render logic
    }
