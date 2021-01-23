      private static IEnumerable<TimeSeriesRecord> FillTimeSeriesGaps(ITimeSeriesProvider timeSeries)
        {
            TimeSpan seriesIntervalTime = new TimeSpan(0, 10, 0);
            DateTime previousDateTime = DateTime.MinValue;
            foreach (GenericTimeSeriesRecord record in timeSeries.Records)
            {
                if (previousDateTime == DateTime.MinValue)
                {
                    yield return record;
                    previousDateTime = record.TimeStamp;
                    continue;
                }
                if (previousDateTime + seriesIntervalTime == record.TimeStamp)
                {
                    yield return record;
                    previousDateTime = record.TimeStamp;
                    continue;
                }
                else
                {
                    yield return new TimeSeriesRecord() { TimeStamp = previousDateTime + seriesIntervalTime, Data = double.NaN };
                    previousDateTime = previousDateTime + seriesIntervalTime;
                }
            }
        }
