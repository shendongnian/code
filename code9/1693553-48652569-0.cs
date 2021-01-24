    public void ChangeGhostMaterials(MaterialSet materialSet)
	{
		foreach (var renderer in Ghost.GetComponentsInChildren<Renderer>())
		{
			var material = materialSet.Materials.FirstOrDefault(x => x.name.Equals(renderer.material.name.Replace(" (Instance)", string.Empty)));
			renderer.material = material ?? renderer.material;
		}
	}
