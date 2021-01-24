    public class ExtendedGeometry : Geometry<ExtendedCords>
    {
         public override SomeNewMagicWithPoints(){...}
         // no need for a redefinition of points since it is inherited from the base class Geometry<ExtendedCords>
    }
