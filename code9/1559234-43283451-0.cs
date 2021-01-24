    Helpers.UnityThreadPool.Instance.Enqueue(() => {
        SimpleTexture t = Assets.Geometry.CubeSphere.CreateTexture(block, (int)Scramble(ID));
        Helpers.UnityMainThreadDispatcher.Instance.Enqueue(() => {
            obj.GetComponent<MeshRenderer>().material.mainTexture = t.ToUnityTexture();
        });
    });
