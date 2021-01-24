    public static String ConvertByteArrayToBase64(int id)
    {
        using (var db = new DBModel())
        {
            return Convert.ToBase64String(db.Articulos.Where(c => c.id_Art == id).First().imagen_Pro);
        }
    }
