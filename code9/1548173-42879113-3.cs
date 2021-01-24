    private List<GameObject> pizzaEnemyList = new List<GameObject>();
    void Start()
    {
        DeactivateAndStoreEnemy();
        Debug.Log(FetchPizzaEnemy());
    }
    private GameObject FetchPizzaEnemy()
    {
        GameObject pizzaEnemy = null;
        foreach (GameObject enemy in pizzaEnemyList)
        {
            if (enemy.activeInHierarchy == false)
            {
                pizzaEnemy = enemy;
                pizzaEnemyList.Remove(enemy);
                return pizzaEnemy;
            }
        }
        return pizzaEnemy;
    }
    public void DeactivateAndStoreEnemy()
    {
        GameObject enemy = new GameObject();
        enemy.name = "PizzaGuy";
        //decativates the enemy
        enemy.SetActive(false);
        //Store the enemy into the correct list
        if (enemy.name == "PizzaGuy")
        {
            pizzaEnemyList.Add(enemy);
        }
    }
