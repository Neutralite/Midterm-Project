using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeedUI : MonoBehaviour
{
    public void ChangeLevelSpeed(int speed)
    {
        Time.timeScale = speed;
    }
}
