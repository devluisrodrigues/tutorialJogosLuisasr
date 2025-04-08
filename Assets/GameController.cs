using UnityEngine;

public static class GameController
{
    private static int collectableCount = 0;

    public static bool gameOver {
        get {
            return collectableCount == 4;
        }
    }

    public static void Init(){
        collectableCount = 0;
    }

    public static void collect(){
        collectableCount++;
    }
    
}
