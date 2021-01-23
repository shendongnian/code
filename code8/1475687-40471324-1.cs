    public class FechaTweetsSerializer : SerializerBase<DateTime>
    {
        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
        {
            context.Writer.WriteString(value.ToString(CultureInfo.InvariantCulture));
        }
        public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var fecha = context.Reader.ReadString();
            return ConvertirFecha(fecha);
        }
        private DateTime ConvertirFecha(string fechaFormatoTwitter)
        {
            var formato = "ddd MMM dd HH:mm:ss zzzz yyyy"; //'Sun Oct 23 19:42:04 +0000 2016'
            var enUS = new CultureInfo("en-US");
            var fechaConvertida = DateTime.ParseExact(fechaFormatoTwitter, formato, enUS, DateTimeStyles.None);
            return fechaConvertida;
        }
    }
    
