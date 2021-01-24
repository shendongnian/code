    static void CreateMaterial()
    {
        // Create a simple material asset
        Material material = new Material(Shader.Find("Specular"));
        AssetDatabase.CreateAsset(material, "Assets/MyMaterial.mat");
        // Add an animation clip to it
        AnimationClip animationClip = new AnimationClip();
        animationClip.name = "My Clip";
        AssetDatabase.AddObjectToAsset(animationClip, material);
        // Reimport the asset after adding an object.
        // Otherwise the change only shows up when saving the project
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(animationClip));
        // Print the path of the created asset
        Debug.Log(AssetDatabase.GetAssetPath(material));
    }
