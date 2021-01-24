    public override Path renderPath(PathPaintingRenderInfo renderInfo)
    {
        Field gsField = PathPaintingRenderInfo.class.getDeclaredField("gs");
        gsField.setAccessible(true);
        GraphicsState graphicsState = (GraphicsState) gsField.get(renderInfo);
        if ((renderInfo.getOperation() & PathPaintingRenderInfo.FILL) != 0)
        {
            var fillColor = graphicsState.getFillColor();
            bool filledRect= false;
            for (PathConstructionRenderInfo pathConstructionRenderInfo in pathInfos) 
            {
                if(pathConstructionRenderInfo.getOperation()==PathConstructionRenderInfo.RECT)
                {
                    filledRect=true;
                    break;
                }
                if (filledRect && fillColor!=null)
                    Console.WriteLine("{0},{1},{2}",
                    fillColor.getRed(), fillColor.getGreen(), fillColor.getBlue());
            }
        }
    }
