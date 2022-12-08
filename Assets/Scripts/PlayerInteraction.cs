using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    private Ray ray;
    public TextMeshProUGUI SceneDia;
    public GameObject Mime;
    public Camera myCamera;
    public GameObject Player;
    public GameObject SitCam;
    public TextMeshProUGUI MimeDia;

    private int CurrentScene=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = myCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 3f))
            {
                
                CommunicateWithCry(raycastHit);
                SitOnChair(raycastHit);
                InteractFailedPeople(raycastHit);
                CommunicateWithFatherInLaw(raycastHit);
                CommunicateWithMotherInLaw(raycastHit);
                CommunicateWithP(raycastHit);
                CommunicateChild(raycastHit);
            }
        }

    }

    private void CommunicateWithCry(RaycastHit raycastHit)
    {
        if (raycastHit.transform.CompareTag("Cry"))
        {
            
            SceneDia.text = "1111111111";
            StartCoroutine(ClearDia(2f));
        }
    }
    private void CommunicateWithFatherInLaw(RaycastHit raycastHit)
    {
        if (raycastHit.transform.CompareTag("P_Father"))
        {

            SceneDia.text = "She came in half an hour ago. Take a seat.";
            StartCoroutine(ClearDia(2f));
        }
    }
    private void CommunicateWithMotherInLaw(RaycastHit raycastHit)
    {
        if (raycastHit.transform.CompareTag("P_Mother"))
        {

            SceneDia.text = "Oh..My girl.";
            StartCoroutine(ClearDia(2f));
        }
    }
    private void CommunicateChild(RaycastHit raycastHit)
    {
        if (raycastHit.transform.CompareTag("Child"))
        {
            Mime.SetActive(true);
            CurrentScene = 2;
            StartCoroutine(MimeGenerator());
            Player.GetComponent<FirstPersonMovement>().enabled = false;
            Player.GetComponent<Jump>().enabled = false;
        }
    }
    private void CommunicateWithP(RaycastHit raycastHit)
    {
        if (raycastHit.transform.CompareTag("P1"))
        {

            SceneDia.text = "Thank you so much, Doctor Benboerba";
            StartCoroutine(ClearDia(2f));
        }
        else if (raycastHit.transform.CompareTag("P2"))
        {

            SceneDia.text = "You saved her!";
            StartCoroutine(ClearDia(2f));
        }
        else if (raycastHit.transform.CompareTag("P3"))
        {

            SceneDia.text = "Thanks a lot!";
            StartCoroutine(ClearDia(2f));
        }
        else if (raycastHit.transform.CompareTag("P4"))
        {

            SceneDia.text = "I don't even know how to thank you.";
            StartCoroutine(ClearDia(2f));
        }
    }
    private void SitOnChair(RaycastHit raycastHit)
    {
        if (raycastHit.transform.CompareTag("Chair"))
        {

            Player.SetActive(false);
            SitCam.SetActive(true);
        }
    }
    private void InteractFailedPeople(RaycastHit raycastHit)
    {
        if (raycastHit.transform.CompareTag("FailPeople"))
        {
            Mime.SetActive(true);
            CurrentScene = 0;
            StartCoroutine(MimeGenerator());
            Player.GetComponent<FirstPersonMovement>().enabled = false;
            Player.GetComponent<Jump>().enabled = false;
        }
    }
    IEnumerator ClearDia(float a)
    {
        yield return new WaitForSeconds(a);
        SceneDia.text = "";
    }
    IEnumerator MimeGenerator()
    {
        switch (CurrentScene)
        {
            case 0:
                MimeDia.text = "Mr. Benboerba…";
                yield return new WaitForSeconds(2f);
                MimeDia.text = "We tried our best...";
                yield return new WaitForSeconds(2f);
                MimeDia.text = "Your wife didn’t make it…";
                yield return new WaitForSeconds(2f);
                //MimeDia.text = "4";
                //yield return new WaitForSeconds(2f);
                CurrentScene++;
                SceneManager.LoadScene(CurrentScene);
               
                break;
            case 1:
                MimeDia.text = "Your wife is in a very good condition.";
                yield return new WaitForSeconds(2f);
                MimeDia.text = "Congratulations!";
                yield return new WaitForSeconds(2f);
                MimeDia.text = "You got a cute twins.";
                yield return new WaitForSeconds(2f);
                MimeDia.text = "You are a father Now!";
                yield return new WaitForSeconds(2f);
                CurrentScene++;
                SceneManager.LoadScene(CurrentScene);
                break;
            case 2:
                MimeDia.text = "Hey Kiddo, your mom is okay now.";
                yield return new WaitForSeconds(2f);
                MimeDia.text = "Don't worry.";
                yield return new WaitForSeconds(2f);
                Application.Quit();
                CurrentScene++;
                break;
        }
        
    }
    public void StartMime(int a)
    {
        Player.SetActive(true);
        Mime.SetActive(true);
        CurrentScene = a;
        StartCoroutine(MimeGenerator());
        Player.GetComponent<FirstPersonMovement>().enabled = false;
    }
}
