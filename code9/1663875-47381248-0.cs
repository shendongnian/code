    {           var client = new MobileServiceClient (Constantes.ApplicationURL);
                IMobileServiceTable perso = client.GetTable ();
                MobileServiceCollection <Personitas, Personitas> items = await perso
                                                  .Where (! Ti => ti.Nombre = null) .ToCollectionAsync ();
                listi.ItemsSource = items.Select (apa => string.Format ( "{0} {1}", apa.Name, apa.LastName));        }
