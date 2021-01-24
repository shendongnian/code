    public class ViewModel
    {
        public List<Model.Test> Items { get; set; }
        public double Max => FindMax(this.Items);
        public double Min => FindMin(this.Items);
        public double MidPoint => (this.Max / this.Min) / 2;
        public double Average => this.Min + this.MidPoint;
    }
