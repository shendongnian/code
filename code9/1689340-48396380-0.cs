    var numbers = new[] { 1, 2, 3, 4, 6, 7, 9 };
    var groups = numbers.GroupConsecutive();
    var serialized = string.Join(", ", groups.Select(i => i.Skip(1).Any() ?
        $"{i.Min()}-{i.Max()}" : $"{i.First()}"));
    var deserialized = serialized.Split(new string[] { ", "}, StringSplitOptions.None)
                                .Select(i => i.Split('-').Select(s => int.Parse(s)).ToArray())
                                .SelectMany(i => i.Length == 1 ? i : Enumerable.Range(i[0], i[1] - i[0] + 1)).ToList();
