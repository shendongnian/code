    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    namespace RoundRobinPartitioning
    {
        public class RoundRobinPartitioner<TSource> : Partitioner<TSource>
        {
            private readonly IList<TSource> _source;
            public RoundRobinPartitioner(IList<TSource> source)
            {
                _source = source;
            }
            public override bool SupportsDynamicPartitions { get { return false; } }
            public override IList<IEnumerator<TSource>> GetPartitions(int partitionCount)
            {
                var enumerators = new List<IEnumerator<TSource>>(partitionCount);
                for (int i = 0; i < partitionCount; i++)
                {
                    enumerators.Add(GetEnumerator(i, partitionCount));
                }
                return enumerators;
            }
            private IEnumerator<TSource> GetEnumerator(
                int partition,
                int partitionCount)
            {
                int position = partition;
                TSource value;
                while (position < _source.Count)
                {
                    value = _source[position];
                    position += partitionCount;
                    yield return value;
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var values = Enumerable.Range(0, 100).ToList();
                var partitioner = new RoundRobinPartitioner<int>(values);
                partitioner.AsParallel()
                    .WithDegreeOfParallelism(4)
                    .ForAll(value =>
                    {
                        // Perform work here
                    });
            }
        }
    }
