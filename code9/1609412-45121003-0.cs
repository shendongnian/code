    public class ColorInverter
    {
        public Color Color1 { get; private set; }
        public Color Color2 { get; private set; }
        public ColorInverter(Color color1, Color color2)
        {
            this.Color1 = color1;
            this.Color2 = color2;
        }
        public void Invert(Control control)
        {
            if (control.BackColor == this.Color1)
            {
                control.BackColor = this.Color2;
                return;
            }
            control.BackColor = Color1;
        }
    }
