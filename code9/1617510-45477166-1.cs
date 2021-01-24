    var queryResult = api.cliente.Execute<Response>(request);
    switch(queryResult.StatusCode)
    {
        case System.Net.HttpStatusCode.OK:
            Usuario u = Tools.CastToObject<Usuario>((IDictionary<string, object>)queryResult.Data.content);
            String status = queryResult.Data.estado;
            Console.Out.WriteLineAsync($"OK - {u.nombreusuario} - {u.email} - Acceso: {u.nivelacceso}");
            break;
        case System.Net.HttpStatusCode.NotFound:
                Console.Out.WriteLineAsync($"Login Failed: User does not exists");
                break;
        case System.Net.HttpStatusCode.Unauthorized:
                Console.Out.WriteLineAsync($"Login Failed: Incorrect Password");
                break;
        default:
                Console.Out.WriteLineAsync($"Error when connecting to the API");
                break;
    }
