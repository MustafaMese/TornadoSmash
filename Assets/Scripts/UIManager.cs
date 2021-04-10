using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance { get => instance; }

    [SerializeField] GameObject startPanel;

    private bool touched;

    private void Awake() 
    {
        instance = this; 
        touched = false;   
    }

    public void Initialize()
    {
        if(!touched)
        {
            touched = true;
            GameManager.Instance.canStart = true;
            startPanel.SetActive(false);
        }
    }

}
