     public async Task ContentAction()
        {
            var constr = _AppSettings.connection;
            var jsonString = "{\"connectionString\""+ constr + "}";
            byte[] data = Encoding.UTF8.GetBytes(jsonString);
            Response.ContentType = "application/json";
            await Response.Body.WriteAsync(data, 0, data.Length);
        }
