    Helpers.UnityThreadPool.Instance.Enqueue(() => {
        // This work is done by a worker thread:
        SimpleTexture t = Assets.Geometry.CubeSphere.CreateTexture(block, (int)Scramble(ID));
        Helpers.UnityMainThreadDispatcher.Instance.Enqueue(() => {
            // This work is done by the Unity main thread:
            obj.GetComponent<MeshRenderer>().material.mainTexture = t.ToUnityTexture();
        });
    });
