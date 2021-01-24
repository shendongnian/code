            IfcStore model = IfcStore.Open(ifcFileName);
            if (model.GeometryStore.IsEmpty)
            {
                var context = new Xbim3DModelContext(model);
                context.CreateContext();
            }
            foreach (var ifcElement in model.Instances.OfType<IfcElement>())
            {
                XbimModelPositioningCollection modelPositions = new XbimModelPositioningCollection();
                short userDefinedId = 0;
                model.UserDefinedId = userDefinedId;
                modelPositions.AddModel(model.ReferencingModel);
                if (model.IsFederation)
                {
                    foreach (var refModel in model.ReferencedModels)
                    {
                        refModel.Model.UserDefinedId = ++userDefinedId;
                        var v = refModel.Model as IfcStore;
                        if (v != null)
                            modelPositions.AddModel(v.ReferencingModel);
                    }
                }
                var modelBounds = modelPositions.GetEnvelopeInMeters();
                var p = modelBounds.Centroid();
                var modelTranslation = new XbimVector3D(-p.X, -p.Y, -p.Z);
                var oneMeter = model.ModelFactors.OneMetre;
                var translation = XbimMatrix3D.CreateTranslation(modelTranslation * oneMeter);
                var scaling = XbimMatrix3D.CreateScale(1 / oneMeter);
                var transform = translation * scaling;
                
                var mat = GetStyleFromXbimModel(ifcElement);
                var m = GetGeometry(ifcElement, transform, mat);
                var myRetTuple = WriteTriangles(m);
              }`
