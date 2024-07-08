using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
    static public int INTELLIGENCE = 16;
    static public int CHARISMA = 8;
    static public int FLY = 4;
    static public int MAGIC = 2;
    static public int INVISIBLE = 1;


    public Text attributeDisplay;
    public int attributes = 0;
    private bool reset = false;

    private void OnTriggerEnter(Collider other)
    {
        //Get Attributes
        if(other.gameObject.tag == "MAGIC")
        {
            attributes |= MAGIC;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "INTELLIGENCE")
        {
            attributes |= INTELLIGENCE;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "CHARISMA")
        {
            attributes |= CHARISMA;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "FLY")
        {
            attributes |= FLY;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "INVISIBLE")
        {
            attributes |= INVISIBLE;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "ANTIMAGIC")
        {
            attributes &= ~MAGIC;
        }
        else if (other.gameObject.tag == "REMOVE")
        {
            attributes &= ~ (INTELLIGENCE | MAGIC);
        }
        else if (other.gameObject.tag == "ADD")
        {
            attributes |= (INTELLIGENCE | MAGIC | CHARISMA);
        }
        else if (other.gameObject.tag == "RESET")
        {
            attributes = 0;
        }
        else if (other.gameObject.tag == "GOLDEN")
        {
            attributes |= INTELLIGENCE + CHARISMA + FLY + MAGIC + INVISIBLE;
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Open door
        if (other.gameObject.tag == "MAGIC_DOOR" && (attributes & MAGIC) != 0)
        {
            other.collider.isTrigger = true;
            attributes &= ~MAGIC;
        }
        else if (other.gameObject.tag == "INTELLIGENCE_DOOR" && (attributes & INTELLIGENCE) != 0)
        {
            other.collider.isTrigger = true;
            attributes &= ~INTELLIGENCE;
        }
        else if (other.gameObject.tag == "CHARISMA_DOOR" && (attributes & CHARISMA) != 0)
        {
            other.collider.isTrigger = true;
            attributes &= ~CHARISMA;
        }
        else if (other.gameObject.tag == "FLY_DOOR" && (attributes & FLY) != 0)
        {
            other.collider.isTrigger = true;
            attributes &= ~FLY;
        }
        else if (other.gameObject.tag == "INVISIBLE_DOOR" && (attributes & INVISIBLE) != 0)
        {
            other.collider.isTrigger = true;
            attributes &= ~INVISIBLE;
        }
        else if (other.gameObject.tag == "CUTE_AND_SMART_DOOR" && (attributes & (CHARISMA + INTELLIGENCE)) != 0)
        {
            other.collider.isTrigger = true;
            attributes &= ~(CHARISMA + INTELLIGENCE);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Lock door
        if (other.gameObject.tag == "MAGIC_DOOR" && (attributes & MAGIC) == 0)
        {
            other.isTrigger = false;
        }
        else if (other.gameObject.tag == "INTELLIGENCE_DOOR" && (attributes & INTELLIGENCE) == 0)
        {
            other.isTrigger = false;
        }
        else if (other.gameObject.tag == "CHARISMA_DOOR" && (attributes & CHARISMA) == 0)
        {
            other.isTrigger = false;
        }
        else if (other.gameObject.tag == "FLY_DOOR" && (attributes & FLY) == 0)
        {
            other.isTrigger = false;
        }
        else if (other.gameObject.tag == "INVISIBLE_DOOR" && (attributes & INVISIBLE) == 0)
        {
            other.isTrigger = false;
        }
        else if (other.gameObject.tag == "CUTE_AND_SMART_DOOR" && (attributes & (CHARISMA + INTELLIGENCE)) == 0) //Pink door
        {
            other.isTrigger = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }
       
}
