    private void HighlightRange(int originX, int originY, int range, bool greenRange = true)
            {
                if (range > 0)
                {
                    List<Tuple<int, int>> hexCoordinates = new List<Tuple<int, int>>();
                    if (originX % 2 == 0)
                    {
                        hexCoordinates.Add(new Tuple<int, int>(originX, originY - 1));
                        hexCoordinates.Add(new Tuple<int, int>(originX - 1, originY - 1));
                        hexCoordinates.Add(new Tuple<int, int>(originX - 1, originY));
                        hexCoordinates.Add(new Tuple<int, int>(originX, originY + 1));
                        hexCoordinates.Add(new Tuple<int, int>(originX + 1, originY));
                        hexCoordinates.Add(new Tuple<int, int>(originX + 1, originY - 1));
                    }
                    else
                    {
                        hexCoordinates.Add(new Tuple<int, int>(originX, originY - 1));
                        hexCoordinates.Add(new Tuple<int, int>(originX - 1, originY));
                        hexCoordinates.Add(new Tuple<int, int>(originX - 1, originY + 1));
                        hexCoordinates.Add(new Tuple<int, int>(originX, originY + 1));
                        hexCoordinates.Add(new Tuple<int, int>(originX + 1, originY + 1));
                        hexCoordinates.Add(new Tuple<int, int>(originX + 1, originY));
                    }
                    hexCoordinates.RemoveAll(t => (t.Item1 < 0 || t.Item1 >= length || t.Item2 < 0 || t.Item2 >= height));
    
                    while (hexCoordinates.Count > 0)
                    {
                        if (range > 1)
                        {
                            HighlightRange(hexCoordinates[0].Item1, hexCoordinates[0].Item2, range - 1, greenRange);
                        }
                        if (greenRange)
                        {
                            gameField[hexCoordinates[0].Item1, hexCoordinates[0].Item2].IsGreenRange = true;
                        }
                        else
                        {
                            gameField[hexCoordinates[0].Item1, hexCoordinates[0].Item2].IsRedRange = true;
                        }
                        hexCoordinates.RemoveAt(0);
                    }
                }
                else
                {
                    return;
                }
            }
