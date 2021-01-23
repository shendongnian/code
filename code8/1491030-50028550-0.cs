    public interface ISupportResistanceCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeseries">timeseries</param>
        /// <param name="beginIndex">starting point (inclusive)</param>
        /// <param name="endIndex">ending point (exclusive)</param>
        /// <param name="segmentSize">number of elements per internal segment</param>
        /// <param name="rangePct"> range % (Example: 1.5%)</param>
        /// <returns> A tuple with the list of support levels and a list of resistance levels</returns>
        Tuple<List<Level>, List<Level>> GetSupportResistance(List<float> timeseries,
            int beginIndex, int endIndex, int segmentSize, float rangePct);
    }
    public enum LevelType
    {
        Support, Resistance
    }
    public class Tuple<TA, TB>
    {
        private readonly TA a;
        private readonly TB b;
        public Tuple(TA a, TB b)
        {
            this.a = a;
            this.b = b;
        }
        public TA GetA()
        {
            return this.a;
        }
        public TB GetB()
        {
            return this.b;
        }
        public String ToString()
        {
            return "Tuple [a=" + this.a + ", b=" + this.b + "]";
        }
    }
    public abstract class CollectionUtils
    {
        public static void Remove<T>(List<T> list,
            List<int> indexes)
        {
            int i = 0;
            for (int j = 0; j < indexes.Count; j++)
            {
                list.RemoveAt(j - i++);
            }
        }
        public static IEnumerable<List<T>> IntoBatches<T>(IEnumerable<T> list, int size)
        {
            if (size < 1)
                throw new ArgumentException();
            var rest = list;
            while (rest.Any())
            {
                yield return rest.Take(size).ToList();
                rest = rest.Skip(size);
            }
        }
    }
    public class Level
    {
        private long serialVersionUID = -7561265699198045328L;
        private LevelType type;
        private readonly float level;
        private readonly float strength;
        public Level(LevelType type, float level, float strength)
        {
            this.type = type;
            this.level = level;
            this.strength = strength;
        }
        public new LevelType GetType()
        {
            return this.type;
        }
        public float GetLevel()
        {
            return this.level;
        }
        public float GetStrength()
        {
            return this.strength;
        }
        public String ToString()
        {
            return "Level [type=" + this.type + ", level=" + this.level
                    + ", strength=" + this.strength + "]";
        }
    }
    public interface ILevelHelper
    {
        float Aggregate(List<float> data);
        LevelType Type(float level, float priceAsOfDate, float rangePct);
        bool WithinRange(float node, float rangePct, float val);
    }
    public class Support : ILevelHelper
    {
        public float Aggregate(List<float> data)
        {
            return data.Min();
        }
        public LevelType Type(float level, float priceAsOfDate,
            float rangePct)
        {
            float threshold = level * (1 - (rangePct / 100));
            return (priceAsOfDate < threshold) ? LevelType.Resistance : LevelType.Support;
        }
        public bool WithinRange(float node, float rangePct,
            float val)
        {
            float threshold = node * (1 + (rangePct / 100f));
            if (val < threshold)
                return true;
            return false;
        }
    }
    public class Resistance : ILevelHelper
    {
        public float Aggregate(List<float> data)
        {
            return data.Max();
        }
        public LevelType Type(float level, float priceAsOfDate,
            float rangePct)
        {
            float threshold = level * (1 + (rangePct / 100));
            return (priceAsOfDate > threshold) ? LevelType.Resistance : LevelType.Support;
        }
        public bool WithinRange(float node, float rangePct,
            float val)
        {
            float threshold = node * (1 - (rangePct / 100f));
            if (val > threshold)
                return true;
            return false;
        }
    }
    public class SupportResistanceCalculator : ISupportResistanceCalculator
    {
        private static readonly int SMOOTHEN_COUNT = 2;
        private static readonly ILevelHelper SupportHelper = new Support();
        private static readonly ILevelHelper ResistanceHelper = new Resistance();
        public Tuple<List<Level>, List<Level>> GetSupportResistance(
            List<float> timeseries, int beginIndex,
            int endIndex, int segmentSize, float rangePct)
        {
            List<float> series = this.SeriesToWorkWith(timeseries,
                beginIndex, endIndex);
            // Split the timeseries into chunks
            List<List<float>> segments = this.SplitList(series, segmentSize);
            float priceAsOfDate = series[series.Count - 1];
            List<Level> levels = new List<Level>();
            this.IdentifySRLevel(levels, segments, rangePct, priceAsOfDate,
                SupportHelper);
            this.IdentifySRLevel(levels, segments, rangePct, priceAsOfDate,
                ResistanceHelper);
            List<Level> support = new List<Level>();
            List<Level> resistance = new List<Level>();
            this.SeparateLevels(support, resistance, levels);
            // Smoothen the levels
            this.Smoothen(support, resistance, rangePct);
            return new BullsEyeStockEx.Controllers.Tuple<List<Level>, List<Level>>(support, resistance);
        }
        private void IdentifySRLevel(List<Level> levels,
            List<List<float>> segments, float rangePct,
            float priceAsOfDate, ILevelHelper helper)
        {
            List<float> aggregateVals = new List<float>();
            // Find min/max of each segment
            foreach (var segment in segments)
            {
                aggregateVals.Add(helper.Aggregate(segment));
            }
            while (aggregateVals.Any())
            {
                List<float> withinRange = new List<float>();
                HashSet<int> withinRangeIdx = new HashSet<int>();
                // Support/resistance level node
                float node = helper.Aggregate(aggregateVals);
                // Find elements within range
                for (int i = 0; i < aggregateVals.Count; ++i)
                {
                    float f = aggregateVals[i];
                    if (helper.WithinRange(node, rangePct, f))
                    {
                        withinRangeIdx.Add(i);
                        withinRange.Add(f);
                    }
                }
                // Remove elements within range
                CollectionUtils.Remove(aggregateVals, withinRangeIdx.ToList());
                // Take an average
                float level = withinRange.Average();
                float strength = withinRange.Count;
                levels.Add(new Level(helper.Type(level, priceAsOfDate, rangePct),
                    level, strength));
            }
        }
        private List<List<float>> SplitList(List<float> series,
            int segmentSize)
        {
            List<List<float>> splitList = CollectionUtils.IntoBatches(series, segmentSize).ToList();
            if (splitList.Count > 1)
            {
                // If last segment it too small
                int lastIdx = splitList.Count - 1;
                List<float> last = splitList[lastIdx].ToList();
                if (last.Count <= (segmentSize / 1.5f))
                {
                    // Remove last segment
                    splitList.Remove(last);
                    // Move all elements from removed last segment to new last
                    // segment
                    foreach (var l in last)
                    {
                        splitList[lastIdx - 1].Add(l);
                    }
                }
            }
            return splitList.ToList();
        }
        private void SeparateLevels(List<Level> support,
            List<Level> resistance, List<Level> levels)
        {
            foreach (var level in levels)
            {
                if (level.GetType() == LevelType.Support)
                {
                    support.Add(level);
                }
                else
                {
                    resistance.Add(level);
                }
            }
        }
        private void Smoothen(List<Level> support,
            List<Level> resistance, float rangePct)
        {
            for (int i = 0; i < SMOOTHEN_COUNT; ++i)
            {
                this.Smoothen(support, rangePct);
                this.Smoothen(resistance, rangePct);
            }
        }
        /**
         * Removes one of the adjacent levels which are close to each other.
         */
        private void Smoothen(List<Level> levels, float rangePct)
        {
            if (levels.Count < 2)
                return;
            List<int> removeIdx = new List<int>();
            levels.Sort();
            for (int i = 0; i < (levels.Count - 1); i++)
            {
                Level currentLevel = levels[i];
                Level nextLevel = levels[i + 1];
                float current = currentLevel.GetLevel();
                float next = nextLevel.GetLevel();
                float difference = Math.Abs(next - current);
                float threshold = (current * rangePct) / 100;
                if (difference < threshold)
                {
                    int remove = currentLevel.GetStrength() >= nextLevel
                                     .GetStrength()
                        ? i
                        : i + 1;
                    removeIdx.Add(remove);
                    i++; // start with next pair
                }
            }
            CollectionUtils.Remove(levels, removeIdx);
        }
        private List<float> SeriesToWorkWith(List<float> timeseries,
            int beginIndex, int endIndex)
        {
            if ((beginIndex == 0) && (endIndex == timeseries.Count))
                return timeseries;
            return timeseries.GetRange(beginIndex, endIndex);
        }
    }
