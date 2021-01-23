    package ...
    import ...
    
    public final class StarWarsDomain extends Domain
    {
        private static final Schema SCHEMA = ...
        public StarWarsDomain( LogicDomain logicDomain, S2Domain delegeeDomain )
        {
            super( logicDomain, SCHEMA, delegeeDomain ); //these get stored in final members of 'Domain'
        }
    
        private <T extends Entity> UnmodifiableEnumerable<T> getAllEntitys( Colonnade<T> colonnade )
        {
            ...
        }
    
        public UnmodifiableEnumerable<Film> getAllFilms()
        {
            return getAllEntitys( Film.COLONNADE );
        }
    
        public Film newFilm( String name )
        {
            assert !StringHelpers.isNullOrEmptyOrWhitespace( name );
            Film film = addEntity( Film.COLONNADE ); //method of 'Domain'
            film.setName( name );
            return film;
        }
    }
