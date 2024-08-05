using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Variables
    private int pickupsCollected = 0; //for unlocking purposes
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

    //PICKUPS and UNLOCKING
    public void ModifyPickupAmount(Attributes pk)
    {
        pickupsCollected |= (int)pk.GetBit();
    }
    public bool TryUnlock(Attributes pk) //if true, unlock door
    {
        if ((pickupsCollected & (int)pk.GetBit()) != 0)
        {
            //Remove key
            pickupsCollected &= ~(int)pk.GetBit();
            return true;
        }
        else
        {
            return false;
        }
    }
}
