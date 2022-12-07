using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToClock : MonoBehaviour
{
    public GameObject MyClock;
    public GameObject CryMan;
    public GameObject FailedPeople;
    public Animator SitcamAnim;
    public GameObject Player;
    public GameObject SitcamObj;
    public GameObject Operation1, Operation2;
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
        CryMan.SetActive(false);
        FailedPeople.SetActive(true);
        StartCoroutine(NormalSpeed(15f));
    }
    IEnumerator NormalSpeed(float a)
    {
        yield return new WaitForSecondsRealtime(a);
        MyClock.GetComponent<Clock>().ChangeClockSpeed(1f);
        yield return new WaitForSecondsRealtime(5f);
        SitcamAnim.SetTrigger("Stand");
        Operation1.SetActive(false);
        Operation2.SetActive(true);
    }
    public void FreeLook()
    {
        SitcamObj.SetActive(false);
        Player.SetActive(true);
  
        //Player.GetComponent<FirstPersonMovement>().enabled = false;
        //Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        //Player.GetComponent<FirstPersonMovement>().enabled = true;
    }
}
