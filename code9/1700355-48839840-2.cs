        /// <summary>
		/// Gets the average y-height of a triangle of Vector3s.
		/// </summary>
		static Func<Vector3, Vector3, Vector3, float> yHeight = (a, b, c) => (a.y + b.y + c.y)/3f;
		/// <summary>
		/// Projects a provided triangle onto the X-Z plane. (If you need to project onto any other plane, this is the function to alter or
		/// replace.)
		/// </summary>
		static Func<Vector3[], Vector3[]> ProjectToY = (points) =>
			new Vector3[]{
			new Vector3(points[0].x, 0, points[0].z), 
			new Vector3(points[1].x, 0, points[1].z), 
			new Vector3(points[2].x, 0, points[2].z) 
		};
		/// <summary>
		/// Determines if point p is on the same side of any given edge, as the opposite edge.
		/// </summary>
		static Func<Vector3, Vector3, Vector3, Vector3, bool> SameSide = (p1, p2, a, b) => {
			return Vector3.Dot(
				Vector3.Cross (b - a, p1 - a),
				Vector3.Cross (b - a, p2 - a)
			) >= 0;
		};
		/// <summary>
		/// Determines whether a point is inside the triangle formed by given Vector3s
		/// </summary>
		static Func<Vector3, Vector3, Vector3, Vector3, bool> PointInTriangle = (p, a, b, c) => {
			return SameSide(p, a, b, c) && SameSide(p, b, a, c) && SameSide(p, c, a, b);
		};
		/// <summary>
		/// Determines whether triangle of Vector3s one intersects triangle of Vector3s two. (Note: Does not check the other way around.
		/// Presumes both are on the same plane.)
		/// </summary>
		static Func<Vector3[], Vector3[], bool> TriangleInTriangle = (one, two) => 
			PointInTriangle(one[0], two[0], two[1], two[2]) ||
			PointInTriangle(one[1], two[0], two[1], two[2]) ||
			PointInTriangle(one[2], two[0], two[1], two[2])
		;
		/// <summary>
		/// Determines whether either of two triangles intersect the other. The one exception would be a case where the triangles overlap,
		/// but do not intersect one another's points. This would require segment intersection tests.
		/// </summary>
		static Func<Vector3[], Vector3[], bool> TrianglesIntersect = (one, two) => 
			TriangleInTriangle(one, two) || TriangleInTriangle(two, one)
		;
		/// <summary>
		/// Organizes a dictionary of triangle indices to average distances by distance, with the furthest at the front.
		/// </summary>
		static Func<Vector3[], int[], Dictionary<int, float>> OrderByHeight = (vertices, triangles) => {
			Dictionary<int, float> height = new Dictionary<int, float>();
			for(int i = 0; i < triangles.Length; i += 3) 
				height.Add(i / 3, yHeight(vertices[triangles[i]], vertices[triangles[i+1]], vertices[triangles[i + 2]]));
			return height;
		}; 
		/// <summary>
		/// Sorts a dictionary of triangle indices to average heights, to a list of the same key value pairs, with the pairs of highest height at the front.
		/// </summary>
		static Func<Dictionary<int, float>, List<KeyValuePair<int, float>>> SortByHeight = (height) => {
			List<KeyValuePair<int, float>> orderedHeight = height.ToList();
			orderedHeight.Sort(
				delegate(KeyValuePair<int, float> a, KeyValuePair<int, float> b) {
					return a.Value > b.Value ? -1 : 1;
				}
			);
			return orderedHeight;
		};
		/// <summary>
		/// Determines whether a provided triangle, in KeyValuePair form of triangle to average distance, is in front of all triangles in a list of pairs.
		/// </summary>
		static Func<KeyValuePair<int, float>, List<KeyValuePair<int, float>>, Vector3[], bool> IsInFront = (pair, top, vertices) => {
			foreach (KeyValuePair<int, float> prevPair in top) {
				if (TrianglesIntersect (
					    ProjectToY (
						    new Vector3[]{ vertices [pair.Key * 3 + 0], vertices [pair.Key * 3 + 1], vertices [pair.Key * 3 + 2] }
					    ),
					    ProjectToY (
						    new Vector3[] {
							vertices [prevPair.Key * 3 + 0],
							vertices [prevPair.Key * 3 + 1],
							vertices [prevPair.Key * 3 + 2]
						}
					    ))) {
					return false;
				}
			}
			return true;
		};
		/// <summary>
		/// Given a list of triangle indices to average heights, sorted by height with highest first, finds the triangles which are unoccluded by closer triangles.
		/// </summary>
		static Func<List<KeyValuePair<int, float>>, Vector3[], List<KeyValuePair<int, float>>> GetUnoccludedTriangles = (orderedHeight, vertices) => {
			List<KeyValuePair<int, float>> top = new List<KeyValuePair<int, float>> ();
			foreach (KeyValuePair<int, float> pair in orderedHeight) {
				if(IsInFront(pair, top, vertices))
					top.Add(pair);
			}
			return top;
		};
		/// <summary>
		/// Converts indices of triangles to indices of the first vertex in the triangle.
		/// </summary>
		static Func<List<KeyValuePair<int, float>>, int[], int[]> ConvertTriangleIndicesToVertexIndices = (top, triangles) => {
			int[] topArray = new int[top.Count * 3];
			for(int i = 0; i < top.Count; i++) {
				topArray[i * 3 + 0] = triangles[top[i].Key * 3 + 0];
				topArray[i * 3 + 1] = triangles[top[i].Key * 3 + 1];
				topArray[i * 3 + 2] = triangles[top[i].Key * 3 + 2];
			}
			return topArray;
		};
		//This seems to work well; but could work better. See to testing it thoroughly, and making it as functional, bulletproof, and short as possible.
		/// <summary>
		/// Determines the unoccluded "top" of a mesh of triangles, and returns it.
		/// </summary>
		static Func<Vector3[], int[], int[]> FindTop = (vertices, triangles) => {
			return ConvertTriangleIndicesToVertexIndices(
				GetUnoccludedTriangles(
					SortByHeight(
						OrderByHeight(vertices, triangles)
					),
					vertices),
				triangles);
		};
