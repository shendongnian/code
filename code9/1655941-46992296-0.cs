    public double CalculatePredictedRSquared(List<MultipleRegressionInfo> listMRInfo, Vector<double> vectorArray)
        {
            double predictedRSquared = 0, press = 0, tss = 0;
            try
            {
                for (int i = 0; i < vectorArray.Count; i++)
                {
                    var matrixArray = CreateMatrix.DenseOfColumnArrays(listMRInfo.ElementAt(0).ListValues.Where((v, j) => j != i).ToArray(), listMRInfo.ElementAt(1).ListValues.Where((v, j) => j != i).ToArray(), 
                        listMRInfo.ElementAt(2).ListValues.Where((v, j) => j != i).ToArray(), listMRInfo.ElementAt(3).ListValues.Where((v, j) => j != i).ToArray(), listMRInfo.ElementAt(4).ListValues.Where((v, j) => j != i).ToArray(), 
                        listMRInfo.ElementAt(5).ListValues.Where((v, j) => j != i).ToArray(), listMRInfo.ElementAt(6).ListValues.Where((v, j) => j != i).ToArray(), listMRInfo.ElementAt(7).ListValues.Where((v, j) => j != i).ToArray(), 
                        listMRInfo.ElementAt(8).ListValues.Where((v, j) => j != i).ToArray(), listMRInfo.ElementAt(9).ListValues.Where((v, j) => j != i).ToArray(), listMRInfo.ElementAt(10).ListValues.Where((v, j) => j != i).ToArray(),
                        listMRInfo.ElementAt(11).ListValues.Where((v, j) => j != i).ToArray());
                    var actualResult = vectorArray.ElementAt(i);
                    var newVectorArray = CreateVector.Dense(vectorArray.Where((v, j) => j != i).ToArray());
                    var items = MultipleRegression.NormalEquations(matrixArray, newVectorArray);
                    var actualList = newVectorArray.ToList();
                    var y = CalculateYIntercept(matrixArray, actualList, items);
                    var estimate = (items.ElementAt(0) * listMRInfo.ElementAt(0).ListValues.ElementAt(i)) + (items.ElementAt(1) * listMRInfo.ElementAt(1).ListValues.ElementAt(i)) +
                            (items.ElementAt(2) * listMRInfo.ElementAt(2).ListValues.ElementAt(i)) + (items.ElementAt(3) * listMRInfo.ElementAt(3).ListValues.ElementAt(i)) +
                            (items.ElementAt(4) * listMRInfo.ElementAt(4).ListValues.ElementAt(i)) + (items.ElementAt(5) * listMRInfo.ElementAt(5).ListValues.ElementAt(i)) +
                            (items.ElementAt(6) * listMRInfo.ElementAt(6).ListValues.ElementAt(i)) + (items.ElementAt(7) * listMRInfo.ElementAt(7).ListValues.ElementAt(i)) +
                            (items.ElementAt(8) * listMRInfo.ElementAt(8).ListValues.ElementAt(i)) + (items.ElementAt(9) * listMRInfo.ElementAt(9).ListValues.ElementAt(i)) +
                            (items.ElementAt(10) * listMRInfo.ElementAt(10).ListValues.ElementAt(i)) + (items.ElementAt(11) * listMRInfo.ElementAt(11).ListValues.ElementAt(i)) + y;
                    press += Math.Pow(actualResult - estimate, 2);
                }
                tss += CalculateTotalSumOfSquares(vectorArray.ToList());
                predictedRSquared = 1 - (press / tss);
            }
            catch (Exception ex)
            {
                predictedRSquared = 0;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return predictedRSquared;
        }
