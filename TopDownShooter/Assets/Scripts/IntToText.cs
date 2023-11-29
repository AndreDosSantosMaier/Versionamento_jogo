using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntToText : MonoBehaviour
{
    public static int currency = 0; 
    public static int GunState = 0;
    public Text currencyText;
    public Text GunStateText;

    void Start()
    {
        
    }


    void Update()
    {
        currencyText.text = currency.ToString();
        GunStateText.text = GunState.ToString();
    }
}
