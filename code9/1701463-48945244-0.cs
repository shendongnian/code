    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace MattConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                var x = new Dictionary<Day, List<WorkSession>>
                {
                    { Day.Tuesday, new List<WorkSession>() { new WorkSession("22:00", "00:00") } },
                    { Day.Monday, new List<WorkSession>() { new WorkSession("20:00", "00:00") } },
                    { Day.Sunday, new List<WorkSession>() { new WorkSession("10:00", "00:00") } }
                };
    
                var y = new Dictionary<Day, List<WorkSession>>
                {
                    { Day.Sunday, new List<WorkSession>() { new WorkSession("10:00", "00:00") } },
                    { Day.Monday, new List<WorkSession>() { new WorkSession("20:00", "00:00") } },
                    { Day.Tuesday, new List<WorkSession>() { new WorkSession("22:00", "00:00") } }
                };
                var w = new MyCustomComparer();
                var shouldBeTrue = w.Equals(x, y);
    
                Console.WriteLine(shouldBeTrue);
    
                x[Day.Wednesday] = new List<WorkSession>() { new WorkSession("10:00", "00:00") };
                x[Day.Thursday] = new List<WorkSession>() { new WorkSession("10:01", "00:01") };
                y[Day.Thursday] = new List<WorkSession>() { new WorkSession("10:00", "00:00") };
                y[Day.Wednesday] = new List<WorkSession>() { new WorkSession("10:01", "00:01") };
    
                var shouldBeFalse = w.Equals(x, y);
    
                Console.WriteLine(shouldBeFalse);
    
                Console.ReadLine();
            }
        }
    
        public class MyCustomComparer : IEqualityComparer<Dictionary<Day, List<WorkSession>>>
        {
            public bool Equals(Dictionary<Day, List<WorkSession>> x, Dictionary<Day, List<WorkSession>> y)
            {
                if (ReferenceEquals(x, null))
                    return ReferenceEquals(y, null);
    
                if (ReferenceEquals(y, null))
                    return false;
    
                if (x.Count != y.Count)
                    return false;
    
                if (!x.Keys.OrderBy(z => z).SequenceEqual(y.Keys.OrderBy(z => z)))
                    return false;
    
                foreach (var kvp in x)
                {
                    List<WorkSession> matching;
                    if (y.TryGetValue(kvp.Key, out matching))
                    {
                        if (ReferenceEquals(matching, null))
                            return ReferenceEquals(kvp.Value, null);
    
                        if (ReferenceEquals(kvp.Value, null))
                            return false;
    
                        // ordering by hash code is not strictly necessary
                        if (
                            !matching.OrderBy(z => z.GetHashCode())
                                .ThenBy(z => z.Entrance).ThenBy(z => z.Exit)
                                .SequenceEqual(
                                    kvp.Value.OrderBy(z => z.GetHashCode())
                                    .ThenBy(z => z.Entrance).ThenBy(z => z.Exit)))
                            return false;
                    }
                    else
                        return false;
                }
    
                return true;
            }
    
            public int GetHashCode(Dictionary<Day, List<WorkSession>> obj)
            {
                throw new NotImplementedException();
            }
        }
    
        public class WorkSession : IEquatable<WorkSession>
        {
            public string Entrance { get; private set; }
            public string Exit { get; private set; }
    
            public WorkSession(string entrance, string exit)
            {
                Entrance = entrance;
                Exit = exit;
            }
    
            public override bool Equals(object obj)
            {
                return Equals(obj as WorkSession);
            }
            public bool Equals(WorkSession other)
            {
                return other != null &&
                       Entrance == other.Entrance &&
                       Exit == other.Exit;
            }
            public override int GetHashCode()
            {
                var hashCode = 1257807568;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Entrance);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Exit);
                return hashCode;
            }
    
            public static bool operator ==(WorkSession session1, WorkSession session2)
            {
                return EqualityComparer<WorkSession>.Default.Equals(session1, session2);
            }
            public static bool operator !=(WorkSession session1, WorkSession session2)
            {
                return !(session1 == session2);
            }
        }
    }
