    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Brick_Spawn_Test : MonoBehaviour {
    
    List<Vector3> positions = new List<Vector3>();
    private int bricks_in_row=9;
    public GameObject Brick;
    private int no_in_row=9;  // No need for a number in row because you have bricks in row which is the same thing.
    private int brick_col=0;  // No need for this variable, as you are going to be count anyways
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
        for (int i = 0; i <= bricks_in_row-1; i++)
        {
            for (int a = -4; a <= no_in_row/2; a++)
            {
                positions.Add(new Vector3(a,brick_col,0f));
            }
            print (brick_col);
            print (positions [i]);
            transform.position = positions[i];
            Instantiate(Brick,transform.position, transform.rotation);
            // brick_col = brick_col + 1;  // This line should be here to update in the loop
        }
        brick_col = brick_col + 1; // This should be before the closing bracket.
        Check_Bricks ();
    }
    
    }
