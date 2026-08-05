using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;

    public void EndGame()
    {
        if (gameOver)
            return;

        gameOver = true;

        Debug.Log("GAME OVER");

        Time.timeScale = 0f;
    }
}