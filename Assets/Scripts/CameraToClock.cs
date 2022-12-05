using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToClock : MonoBehaviour
{
    public GameObject MyClock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CToC()
    {
        MyClock.GetComponent<Clock>().ChangeClockSpeed(500f);
        StartCoroutine(NormalSpeed(15f));
    }
    IEnumerator NormalSpeed(float a)
    {
        yield return new WaitForSeconds(a);
        MyClock.GetComponent<Clock>().ChangeClockSpeed(1f);
    }
}
