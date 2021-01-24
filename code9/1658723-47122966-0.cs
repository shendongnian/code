    public Vector<double> CalculateWithQR(Matrix<double> x, Vector<double> y)
        {
            Vector<double> result = null;
            try
            {
                result = MultipleRegression.QR(x, y);
                // check for NaN and infinity
                for (int i = 0; i < result.Count; i++)
                {
                    var value = result.ElementAt(i);
                    if (Double.IsNaN(value) || Double.IsInfinity(value))
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public Vector<double> CalculateWithNormal(Matrix<double> x, Vector<double> y)
        {
            Vector<double> result = null;
            try
            {
                result = MultipleRegression.NormalEquations(x, y);
                // check for NaN and infinity
                for (int i = 0; i < result.Count; i++)
                {
                    var value = result.ElementAt(i);
                    if (Double.IsNaN(value) || Double.IsInfinity(value))
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public Vector<double> CalculateWithSVD(Matrix<double> x, Vector<double> y)
        {
            Vector<double> result = null;
            try
            {
                result = MultipleRegression.Svd(x, y);
                // check for NaN and infinity
                for (int i = 0; i < result.Count; i++)
                {
                    var value = result.ElementAt(i);
                    if (Double.IsNaN(value) || Double.IsInfinity(value))
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        public Vector<double> FindBestMRSolution(Matrix<double> x, Vector<double> y)
        {
            Vector<double> result = null;
            try
            {
                result = CalculateWithNormal(x, y);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    result = CalculateWithSVD(x, y);
                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        result = CalculateWithQR(x, y);
                        if (result != null)
                        {
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
