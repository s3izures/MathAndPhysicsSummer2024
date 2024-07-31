using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Variables
    private bool isCarMode = false;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else if (Instance == null && Instance != this)
        {
            Instance = this;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            ToggleCarMode(true);
        }
    }

    public void ToggleCarMode(bool cm)
    {
        isCarMode = cm;
    }
    public bool GetCarMode()
    {
        return isCarMode;
    }
}
