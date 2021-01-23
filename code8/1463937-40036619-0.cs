            var builder = new StringBuilder();
            list.Aggregate(builder, (sb, person) =>
            {
                sb.Append(",");
                sb.Append("[");
                sb.Append(person.Name);
                sb.Append("]");
                return sb;
            });
            builder.Remove(0, 1); // Remove first comma
