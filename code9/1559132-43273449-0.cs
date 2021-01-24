     private int[,,] _space = new int[width, height, depth];
        public int[,] GetCrossSection(int position, int dimension)
        {
            if (dimension < 0 || dimension > 2) return null;
            if (position > _space.GetLength(dimension) || position < 0) return null;
            var minMax = new Tuple<int, int>[3];
            var resultXLength = -1;
            var resultYLength = -1;
            for (var i = 0; i < _space.GetLength(i); i++)
            {
                if (i == dimension)
                {
                    minMax[i] = new Tuple<int, int>(position, position+1);
                }
                else
                {
                    minMax[i] = new Tuple<int, int>(0,_space.GetLength(i));
                    if (resultXLength == -1) resultXLength = _space.GetLength(i);
                    else resultYLength = _space.GetLength(i);
                }
            }
            var result = new int[resultXLength, resultYLength];
            for (var i = minMax[0].Item1; i < minMax[0].Item2; i++)
                for (var j = minMax[1].Item1; j < minMax[1].Item2; j++)
                    for (var k = minMax[2].Item1; k < minMax[2].Item2; k++)
                    {
                        switch (dimension)
                        {
                            case 0:
                            {
                                result[j, k] = _space[i, j, k];
                                break;
                            }
                            case 1:
                            {
                                result[i, k] = _space[i, j, k];
                                break;
                            }
                            case 2:
                            {
                                result[i, j] = _space[i, j, k];
                                break;
                            }
                        }
                    }
            return result;
        }
