    public void RegisterSelectControls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var clickLocation = Input.mousePosition;
            Transform closestBone = null;
            this.MinimumRecursiveBoneDistance(clickLocation, SpineRoot, out closestBone);
            if(null != closestBone)
            {
                Debug.Log(closestBone.gameObject.name);
            }
        }
    }
    public float MinimumRecursiveBoneDistance(Vector3 clickLocation, Transform root, out Transform closestBone)
    {
        float minimumDistance = float.MaxValue;
        closestBone = null;
        foreach (Transform bone in root)
        {
            
            var boneScreenPoint = Camera.main.WorldToScreenPoint(bone.position);
            var distance = Math.Abs(Vector3.Distance(clickLocation, boneScreenPoint));
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                closestBone = bone;
            }
            if (bone.childCount > 0)
            {
                Transform closestChildBone;
                var minimumChildDistance = this.MinimumRecursiveBoneDistance(clickLocation, bone, out closestChildBone);
                if(minimumChildDistance < minimumDistance)
                {
                    minimumDistance = minimumChildDistance;
                    closestBone = closestChildBone;
                }
            }
        }
        return minimumDistance;
    }
