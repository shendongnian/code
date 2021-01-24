    protected override void InitializeDecorators(IList<ShapeField> shapeFields, IList<Decorator> decorators)
        {
            base.InitializeDecorators(shapeFields, decorators);
            var oldDecorator = decorators.FirstOrDefault(d => d.Field.Name == "EditCodeDecorator");            
            if (oldDecorator == null)
                return;
            decorators.Remove(oldDecorator);
            ImageField editCodeImageField = new ShowCodeImageField("EditCodeDecorator")
            {
                DefaultImage = ImageHelper.GetImage(
                    PFlowDomainModel.SingletonResourceManager.GetObject("BaseShapeEditCodeDecoratorDefaultImage"))
            };
            var newDecorator = new ShapeDecorator(editCodeImageField, ShapeDecoratorPosition.OuterTopRight, new PointD(-0.1, -0.1));
            decorators.Add(newDecorator);
        }
    public override void OnDoubleClick(DiagramPointEventArgs e)
        {
            base.OnDoubleClick(e);
            var decoratorHostShape = e.HitDiagramItem.RepresentedElements.Cast<DecoratorHostShape>().First();
            
            var shape = decoratorHostShape.ParentShape;         
            if (shape != null)
            {
                InteractionEvents.OnRegisterFileBuildEvent(shape);
                e.Handled = true;
            }
        }
