using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    [SerializeField] private GameManager.AttributeType attributeValue;
    public GameManager.AttributeType GetBit()
    {
        return attributeValue;
    }
}
