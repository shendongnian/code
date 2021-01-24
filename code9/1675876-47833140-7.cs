    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Brick_Spawn_Test : MonoBehaviour {
    
    List<Vector3> positions = new List<Vector3>();
    private int bricks_in_row=9;
    public GameObject Brick;
    private int no_in_row=9;  // No need for a number in row because you have bricks in row which is the same thing.
    private int brick_col=0;  // No need for this variable, as you are going to be counting anyways (in this case your i variable)
    private int number_of_brick_col=2;
    
    void Start(){
        Check_Bricks ();
    }
    
    
    void Check_Bricks(){  // This function is unnessary, it appears it may have been added when you were trying to fix your y issue.
        if (brick_col != number_of_brick_col) {
            print ("not enough bricks");
            Create_Bricks ();
        }
    } 
    
    
    void Create_Bricks(){
        for (int i = 0; i <= bricks_in_row-1; i++) // This will run 9 times.
        {
            for (int a = -4; a <= no_in_row/2; a++) // This will also run 9 times
            {
                positions.Add(new Vector3(a,brick_col,0f));
            }
            // Move all this into the inner loop.
            print (brick_col);
            print (positions [i]); // By this point you will have 9 then 18 then 27... as your inner loop this position would be positons[i * bricks_in_row + (a +4)] with how you are looping
            transform.position = positions[i]; /// This positions should be based off of the individual brick, next time around you are setting this position to the second index but by this time you have 18.
            Instantiate(Brick,transform.position, transform.rotation);
            // 
            // brick_col = brick_col + 1; This will be in the outter loop  
        }
        brick_col = brick_col + 1; // This should be before the closing bracket. not outside the loop
        Check_Bricks ();
    }
    
    }
