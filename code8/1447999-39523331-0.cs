    public bool FeatureFits(Feature feature, MathDR.PosDirObj wall)
        {
            // Get required parameters
			Vect3 dir = wall.direction;
            Vect3 pos = wall.position;
            Vect3 size = feature.size;
            if (dir.x == 0)
                dir.x = 1;
            if (dir.y == 0)
                dir.y = 1;
			if (dir.z == 0)
				dir.z = 1;
            int padding = 1;
            int x1 = pos.x - padding;
            int x2 = pos.x + (size.x * dir.x) + padding;
            int y1 = pos.y - padding;
            int y2 = pos.y + (size.y * dir.y) + padding;
            int z1 = pos.z - padding;
            int z2 = pos.z + (size.z * dir.z) + padding;
            // Check if outside bounds
            if (x1 < 0 ||
                x2 < 0 ||
                y1 < 0 ||
                y2 < 0 ||
                z1 < 0 ||
                z2 < 0 ||
                x1 > worldSize.x ||
                x2 > worldSize.x ||
                y1 > worldSize.y ||
                y2 > worldSize.y ||
                z1 > worldSize.z ||
                z2 > worldSize.z) {
				return false;
            }
            // Checks for every block that the feature will take + 1 padding
			for (int x = System.Math.Min(x1, x2); x <= System.Math.Max(x1, x2); x++)
            {
				for (int y = System.Math.Min(y1, y2); y <= System.Math.Max(y1, y2); y++)
                {
					for (int z = System.Math.Min(z1, z2); z <= System.Math.Max(z1, z2); z++)
                    {
                        if (blocks[x, y, z] != BlockType.Air)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
