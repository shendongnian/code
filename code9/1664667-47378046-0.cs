    private Action GetPlayerAction(manager, player, enemy, actionType, param1, param2, param3)
    {
        switch(actionType) {
            case actionType1:
                return () => { manager.attack(param1, player, enemy); checkIfPlayerWon(); }
            case actionType2:
                return () => manager.heal(param2, player);
            // ....
        }
    }
    // to use
    var playerAction = GetPlayerAction(manager, player, enemy, param1, param2);
    // do some things ...
    playerAction();
