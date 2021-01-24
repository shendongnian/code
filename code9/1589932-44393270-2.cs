    IGameObject player = new Player();
    IGameObject projectile = new Projectile();
    
    player.OnCollision(projectile);
    projectile.OnCollision(player);
