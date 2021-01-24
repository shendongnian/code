    Collider[] collisions = Physics.OverlapSphere(transform.position,.75f);
    		foreach (Collider C in collisions) {
    			Debug.Log("In Foreach for: " + C.name.ToString());
    			if (C.transform.CompareTag ("Enemy Unit")) {
    				Debug.Log (C.name.ToString () + " Is an enemy");
    				int Dmg = MM.MoveStat (Ours, SM.selected.GetComponent<EidolonClass> (), C.transform.gameObject.GetComponent<EidolonClass> ());
    				C.transform.gameObject.GetComponent<EidolonClass> ().TakeDamage (Dmg);
    			}
    		}
