    public class ModuloModelComparer : Comparer<ModuloModel>
    {
        public override int Compare(ModuloModel x, ModuloModel y)
        {
            //They are the same node.
            if (x.Equals(y))
                return 0;
            
            //Find the shared parent
            if (x.Profundidade > y.Profundidade)
            {
                //x is a child of y
                if (x.ModuloPai.Equals(y))
                    return 1;
                return Compare(x.ModuloPai, y);
            }
            else if (y.Profundidade > x.Profundidade)
            {
                //y is a child of x
                if (x.Equals(y.ModuloPai))
                    return -1;
                return Compare(x, y.ModuloPai);
            }
            else
            {
                //They both share a parent but are not the same node, just compare on Ordem.
                if (x.ModuloPai.Equals(y.ModuloPai))
                    return x.Ordem.CompareTo(y.Ordem);
                //They are the same level but have diffrent parents, go up a layer
                return Compare(x.ModuloPai, y.ModuloPai);
            }
        }
    }
