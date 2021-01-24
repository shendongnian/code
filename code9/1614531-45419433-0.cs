        public IMesh DeleteVertices(IMesh mesh, IImmutableList<int> indices_to_remove)
        {
            var indices_to_remove_set = new HashSet<int>(indices_to_remove);
            var new_vertices = new List<Vector>();
            var map = new int[mesh.Vertices.Count];
            for (var i = 0; i < mesh.Vertices.Count; i++)
            {
                if (indices_to_remove_set.Contains(i))
                {
                    map[i] = -1;
                }
                else
                {
                    new_vertices.Add(mesh.Vertices[i]);
                    map[i] = new_vertices.Count - 1;
                }
            }
            var new_triangle_list = from triangle in mesh.Triangles
                                    where map[triangle.A] != -1 &&
                                          map[triangle.B] != -1 &&
                                          map[triangle.C] != -1
                                    select new IndexTriangle(
                                        map[triangle.A],
                                        map[triangle.B],
                                        map[triangle.C]);
            //build new mesh...
        }
