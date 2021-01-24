    public class Graph
    {
    
    	public bool NeedsBackPropagation { get; }
    	public List<Action> BackProp { get; }
    
    
    	public Graph(bool backProp)
        {
            NeedsBackPropagation = backProp;
            BackProp = new List<>();
        }
    
    
        public Matrix RowPluck(Matrix m, int ix)
        {
            Util.Assert(ix >= 0 && ix < m.NumberOfRows);
            var d = m.NumberOfColumns;
            var outt = new Matrix(d, 1);
            for (int i = 0, n = d; i < n; i++)
            {
                outt.Weights[i] = m.Weights[d * ix + i];
            }
    
            if (NeedsBackPropagation)
            {
                BackProp.Add(new Action(() => {
                	for (int i = 0, n = d; i < n; i++)
    	            {
    	                m.BackPropWeights[d * ix + i] += outt.BackPropWeights[i];
    	            }
                }));
            }
    
            return outt;
        }
    
    }
