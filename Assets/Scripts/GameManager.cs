using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    public bool canStart;

    private void Awake() 
    {
        instance = this;
        Application.targetFrameRate = 60;
    }

    private void Start() 
    {
        canStart = false;
    }
}
