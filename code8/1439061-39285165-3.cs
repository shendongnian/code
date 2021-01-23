			private void MapLineToPixels(ITextSnapshotLine line, out double top, out double bottom)
			{
			double mapTop = ScrollBar.Map.GetCoordinateAtBufferPosition(line.Start) - 0.5;
			double mapBottom = ScrollBar.Map.GetCoordinateAtBufferPosition(line.End) + 0.5;
			top = Math.Round(ScrollBar.GetYCoordinateOfScrollMapPosition(mapTop)) - 2.0;
			bottom = Math.Round(ScrollBar.GetYCoordinateOfScrollMapPosition(mapBottom)) + 2.0;
			}
