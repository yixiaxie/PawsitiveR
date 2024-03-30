using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using UnityEditor;
using TMPro;

public class SensorRead : MonoBehaviour
{
    UduinoManager uduinoManager;
    public int forceRead;
    public int forceToLength;
    [SerializeField]private TextMeshProUGUI rawReadUI;

    // Start is called before the first frame update
    void Start()
    {
        uduinoManager = UduinoManager.Instance;
        uduinoManager.pinMode(AnalogPin.A0, PinMode.Input);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ReadValueTenTimesPerSec());     
    }
    IEnumerator ReadValueTenTimesPerSec(){
        while(true){
            forceRead = uduinoManager.analogRead(AnalogPin.A0);
            forceToLength = forceRead - 900; 
            rawReadUI.text = forceRead.ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
