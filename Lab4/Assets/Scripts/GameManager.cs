using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Variables
    private bool isCarMode = false;

    private int pickupsCollected = 0; //for unlocking purposes
    private int pickupsCollectedInLifetime = 0; //for display purposes
    public enum AttributeType { RED = 1, GREEN = 2, BLUE = 4, YELLOW = 8 }

    void Awake()
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

    //MOVEMENT
    public void ToggleCarMode()
    {
        isCarMode = !isCarMode;
    }
    public bool GetCarMode()
    {
        return isCarMode;
    }

    //PICKUPS and UNLOCKING
    public void ModifyPickupAmount(Attributes pk)
    {
        pickupsCollected |= (int)pk.GetBit();
        pickupsCollectedInLifetime |= (int)pk.GetBit();
    }
    public bool TryUnlock(Attributes pk) //if true, unlock door
    {
        if ((pickupsCollected & (int)pk.GetBit()) != 0)
        {
            //Remove key
            pickupsCollected &= ~(int)pk.GetBit();
            Debug.Log("Unlocked a door!");
            return true;
        }
        else
        {
            return false;
        }
    }
}
