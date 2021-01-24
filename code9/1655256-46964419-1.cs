    var sb = new StringBuilder();
    for (int i = 0; i < reader.FieldCount; i++) {
        sb.Append($"{reader[i]} \t |");
    }
    sb.Length -= 4; // Remove the last " \t |".
    Console.WriteLine(sb);
