using UnityEngine;

public static class GameController
{
    private static int collectableCount = 0;
    private static bool encostouInimigoFlag = false;

    public static bool gameOver {
        get {
            return encostouInimigoFlag;
        }
    }

    public static void Init(){
        collectableCount = 0;
        encostouInimigoFlag = false;
    }

    public static void collect(){
        collectableCount++;
    }

    public static void encostouInimigo(){
        encostouInimigoFlag = true;
    }
    
}
