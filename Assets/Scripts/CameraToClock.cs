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
    public AudioSource clock;
    public AudioSource dead;
    public AudioSource problemBeat;
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
        CryMan.SetActive(false);
        FailedPeople.SetActive(true);
        StartCoroutine(NormalSpeed(25f));
    }
    IEnumerator NormalSpeed(float a)
    {
        yield return new WaitForSecondsRealtime(a);
        clock.Pause();
        MyClock.GetComponent<Clock>().ChangeClockSpeed(1f);
        dead.Play();
        problemBeat.Stop();
        yield return new WaitForSecondsRealtime(5f);
        SitcamAnim.SetTrigger("Stand");
        Operation1.SetActive(false);
        Operation2.SetActive(true);
    }
    public void FreeLook()
    {
        SitcamObj.SetActive(false);
        Player.SetActive(true);
        this.transform.parent.tag = "Untagged";
        //Player.GetComponent<FirstPersonMovement>().enabled = false;
        //Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        //Player.GetComponent<FirstPersonMovement>().enabled = true;
    }
}
