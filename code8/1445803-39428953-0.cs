    public class ColorMap : ClassMap<Color>
    {
            public ColorMap()
            {
                Table("Line_Color");
                Id(x => x.Id);
                Map(x => x.ColorS).Column("Color");
            }
    }
