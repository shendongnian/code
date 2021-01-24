    using System.IO;
    using Xbim.Common.Geometry;
    using Xbim.Ifc;
    using Xbim.ModelGeometry.Scene;
    using Xbim.Common.XbimExtensions;
    
    namespace CreateWexBIM
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string file = @"4walls1floorSite.ifc";
    
                var model = IfcStore.Open(file);
                var context = new Xbim3DModelContext(model);
                context.CreateContext();
    
                var instances = context.ShapeInstances();
                foreach (var instance in instances)
                {
                    var geometry = context.ShapeGeometry(instance);
                    var data = ((IXbimShapeGeometryData)geometry).ShapeData;
                    using (var stream = new MemoryStream(data))
                    {
                        using (var reader = new BinaryReader(stream))
                        {
                            var mesh = reader.ReadShapeTriangulation();
                        }
                    }
                }
            }
    
        }
    }
