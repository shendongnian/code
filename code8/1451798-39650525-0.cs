        public static T[,] OrderBy<T>(this T[,] source, Func<T[], T> inKeySelector, IList<int> inThenByColumns)
        {
            var mySingleDimensionArray = source.ConvertToSingleDimension().OrderBy(inKeySelector);
            if (inThenByColumns.Count > 0)
            {
                mySingleDimensionArray = inThenByColumns.Aggregate(
                    mySingleDimensionArray, 
                    (myCurrent, myColumn) => myCurrent.ThenBy(x => x[myColumn]));
            }
            return mySingleDimensionArray.ConvertToMultiDimensional();
        }
