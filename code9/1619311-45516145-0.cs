    public class ListCanvasBlocks : List<MyBlock>
    {
        public ListCanvasBlocks MyCopySelectedObj()
        {
            var x = new ListCanvasBlocks();
            x.AddRange(this.Where(z => z.IsSelected));
            return x;
        }
    }
