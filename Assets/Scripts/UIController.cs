using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private UIKeyBar keyBar;

    [SerializeField] private TextMeshProUGUI gameTimerText;

    public void UpdateGameTime(float gameTime)
    {
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);

        gameTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void InitializeKeyBar(int totalKeys)
    {
        keyBar.InitializeKeys(totalKeys);
    }

    public void UpdateKeyBar(int collectedKeys)
    {
        keyBar.UpdateKeyIcons(collectedKeys);
    }
}
