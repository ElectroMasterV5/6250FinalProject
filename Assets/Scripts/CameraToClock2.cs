using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToClock2 : MonoBehaviour
{
    public GameObject MyClock;
    public Animator SitcamAnim;
    public GameObject Player;
    public GameObject SitcamObj;
    public GameObject SitcamObj2;
    public GameObject Timeline;
    public GameObject ParentsB;
    public GameObject ParentsA;
    public GameObject Operation1, Operation2;
    public AudioSource clock;
    public AudioSource baby;
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
        clock.Play();
        MyClock.GetComponent<Clock>().ChangeClockSpeed(300f);
        ParentsB.SetActive(false);
        ParentsA.SetActive(true);
        StartCoroutine(NormalSpeed(25f));
    }
    IEnumerator NormalSpeed(float a)
    {
        yield return new WaitForSecondsRealtime(a);
        clock.Pause();
        MyClock.GetComponent<Clock>().ChangeClockSpeed(1f);
        baby.Play();
        yield return new WaitForSecondsRealtime(15f);
        //SitcamAnim.SetTrigger("Stand");
        SitcamObj2.SetActive(true);
        SitcamObj.SetActive(false);
        Operation1.SetActive(false);
        Operation2.SetActive(true);
        Timeline.SetActive(true);
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
