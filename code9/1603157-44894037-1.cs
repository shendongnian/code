            writer.WriteStartArray(); // <-- Line 89
            for (int i = 0; i < 2; i++)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("type");
                writer.WriteValue("type_" + i);
                writer.WritePropertyName("name");
                writer.WriteValue("type_" + i);
                writer.WritePropertyName("position");
                writer.WriteStartObject();
                writer.WritePropertyName("x");
                writer.WriteValue("position.x_" + i);
                writer.WritePropertyName("z");
                writer.WriteValue("position.a_" + i);
                writer.WritePropertyName("rot");
                writer.WriteValue("position.rot_" + i);
                writer.WriteEndObject();
                writer.WritePropertyName("flags");
                writer.WriteValue("flags_" + i);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
