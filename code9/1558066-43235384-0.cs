    using System.Windows;
    using System.Windows.Media;
    ...
    var originalPoint = new Vector(10, 0);
    var transform = Matrix.Identity;
    transform.Rotate(45.0); // 45 degree rotation
    var rotatedPoint = originalPoint * transform;
