    public void generateGalaxy()
    {
        for(int i = 0; i < numOfStars; i++)
        {
            Star testStar = spawnStar();
        }
    }
    
    public Star spawnStar()
    {
        return new Star(){starName="star1"}; //Using object initializer and anonymous class
    }
