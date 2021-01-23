    class FT {
        public string Name { get; set; }
        public FT Clone() {
            var x = new FT();
            x.Name = this.Name;
            return x;
        }
    }
