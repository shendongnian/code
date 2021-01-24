    public void UseItem(){
            if (item != null) {
                if (item is Food) { //checking if item is Food type..
                    PHH.Heal(((Food)item).healthHealedOnUse); //Cast item to Food..
                } else {
                    item.Use ();
                }
            }
        }
