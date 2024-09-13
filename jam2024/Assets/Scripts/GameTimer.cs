
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float _timer;

    //REMOVING THIS LATER WHEN WE HAVE REAL LEVEL TIMERS
    private void Start()
    {
        GetLevelTimer(100);
    }

    void Update()
    {
        if (GameMaster.GameRunning) DoCountDown();
    }

    private void DoCountDown()
    {
        _timer -= Time.deltaTime;
        timerText.text = _timer.ToString("00.0");
    }

    public void GetLevelTimer(int seconds)
    {
        _timer = seconds;
    }
}
