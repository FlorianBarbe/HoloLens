using UnityEngine;
using TMPro;

public class TimerCountdown : MonoBehaviour
{
    public TextMeshPro timerText;
    public float timeRemaining = 120f; // 2 minutes
    private bool timerRunning = true;

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                DisplayTime(timeRemaining);
                Debug.Log("Temps écoulé !");
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Si il reste 10 secondes ou moins, le texte devient rouge
        if (timeToDisplay <= 10)
        {
            timerText.color = Color.red;
        }
    }
}