    public class Graph
    {
        public Dictionary<int, List<KeyValuePair<int, int>>> vertices = new Dictionary<int, List<KeyValuePair<int, int>>>();
    
        public void AddVertex(int id, List<KeyValuePair<int, int>> edges)
        {
            if(!vertices.ContainsKey(id))
            {
                  vertices.Add(id, new List<KeyValuePair<int, int>>());
            }
            vertices[id].AddRange(edges);
        }
    }
    public int Id { get; set; }
    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right)
        {
            var result = circleManager.HitTest(e.Location);
            if (result != -1)
            {
                circlesSourceAndDestination.Add(circleManager.Circles[result]);
                if (Count == 1)
                {
                    Id = result;
                }
                else if (Count == 2)
                {
                    var weigth = CalculateLengthSourceAndDestination(circlesSourceAndDestination);
                    circlesSourceAndDestination.Clear();
                    if (weigth < 0)
                    {
                        weigth *= -1;
                    }
                    var neighbor = new KeyValuePair<int, int>(result, weigth);
                    var list = new List<KeyValuePair<int, int>> { neighbor };
                    g.AddVertex(Id, list);
                    
                    Count = 0;
                }
                Count++;
            }
        }
        else
        {
            var result = circleManager.HitTest(e.Location);
            if (result != -1)
            {
                circleManager.Circles[circleManager.HitTest(e.Location)].Selected = true;
                circleManager.Circles[result].SelectFillColor = Color.Red;
            }
        }
        pictureBox1.Invalidate();
    }
