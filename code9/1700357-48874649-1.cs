		public override void GetAppropriateIndices (Mesh mesh)
		{
			this.indices = new HashSet<int> (mesh.triangles.AsEnumerable ().Distinct ().Where (index => 
				Vector3.Angle(mesh.normals [index], Vector3.up) < ε
			).ToList());
		}
    
