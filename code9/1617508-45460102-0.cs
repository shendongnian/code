		HttpStatusCode statusCode = queryResult.StatusCode;
		int numericStatusCode = (int)statusCode;
		
		switch (numericStatusCode)
        {
            case 202:
                dynamic content = queryResult.Data.content;
				Usuario u = content.content; 
			    String s = queryResult.Data.estado;
			    Console.Out.WriteLineAsync($"OK - {u.nombreusuario} - {u.email} - Acceso: {u.nivelacceso}");
                break;
            case 401:
                //Deal with the failed login
                break;
        }
