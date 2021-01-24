    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public static class shooterMain {
    public enum ShooterStatenum{shielded,Vulnerable};
    
    private static float ballSpeed = 2;
    private static int points = 0;
    private static int lives = 0;
    public static ShooterStatenum shooterState = ShooterStatenum.Vulnerable;
    
    public static float getBallSpeed ()
    {
        return ballSpeed;
    }
    
    public static void IncreaseSpeed()
    {
        ballSpeed += 0.2f;
    }
    
    public static void increasePoint()
    {
        points++;
    }
    
    public static void ResetSpeed()
    {
        ballSpeed = 2;
    }
    
    public static void ResetPoint()
    {
        points = 0;
    }
    
    public static int getPoints()
    {
        return points;
    }
    
    public static int getLives(){
    
        return lives;
    
    }
    
    public static void addLives(){
    
        lives++;
    
    }
