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
    public GameObject BGM;
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
                CommunicateFChild(raycastHit);
                PickPost(raycastHit);
            }
        }

    }

    private void CommunicateWithCry(RaycastHit raycastHit)
    {
        if (raycastHit.transform.CompareTag("Cry"))
        {
            
            SceneDia.text = "Your mom will be fine. I hope ...";
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
            CurrentScene = 3;
            StartCoroutine(MimeGenerator());
            Player.GetComponent<FirstPersonMovement>().enabled = false;
            Player.GetComponent<Jump>().enabled = false;
        }
    }
    private void CommunicateFChild(RaycastHit raycastHit)
    {
        if (raycastHit.transform.CompareTag("FakeChild"))
        {
            Mime.SetActive(true);
            CurrentScene = 4;
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
    private void PickPost(RaycastHit raycastHit)
    {
        if (raycastHit.transform.CompareTag("Post"))
        {
            raycastHit.transform.GetComponent<Post>().Pickup();
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
                BGM.SetActive(true);
                MimeDia.text = "\"Mr. Benboerba…\"";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "\"We tried our best...\"";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "\"Your wife didn’t make it…\"";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "From that day, I lost my mom.";
                yield return new WaitForSeconds(5f);
                CurrentScene++;
                SceneManager.LoadScene(CurrentScene);
               
                break;
            case 1:
                GameObject.Find("BGM").SetActive(false);
                if (PostManager.postpicked)
                {
                    MimeDia.text = "\"Mom\"";
                    yield return new WaitForSeconds(3f);
                    MimeDia.text = "\"Why couldn't they save you?\"";
                    yield return new WaitForSeconds(3f);
                    MimeDia.text = "This sorrow...";
                    yield return new WaitForSeconds(3f);
                    MimeDia.text = "No one should experience...";
                    yield return new WaitForSeconds(5f);
                }
                if (!PostManager.postpicked)
                {
                    MimeDia.text = "\"Mom\"";
                    yield return new WaitForSeconds(3f);
                    MimeDia.text = "\"Why couldn't they save you?\"";
                    yield return new WaitForSeconds(3f);
                    MimeDia.text = "This sorrow...";
                    yield return new WaitForSeconds(3f);
                    MimeDia.text = "It swallowed me...";
                    yield return new WaitForSeconds(5f);
                }
                CurrentScene++;
                SceneManager.LoadScene(CurrentScene);

                break;
            case 2:
                BGM.SetActive(true);
                MimeDia.text = "\"Your wife is in a very good condition.\"";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "\"Congratulations!\"";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "\"You got a cute twins.\"";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "\"You are a father Now!\"";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "Facing a new born life makes me know the preciousness of life.";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "Many years later, I got the chance to save someone else's life";
                yield return new WaitForSeconds(5f);
                if (!PostManager.postpicked)
                {
                    CurrentScene++;
                }
                CurrentScene++;
                SceneManager.LoadScene(CurrentScene);
                break;
            case 3:
                BGM.SetActive(true);
                MimeDia.text = "\"Hey Kiddo, your mom is okay now.\"";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "\"Don't worry.\"";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "Seeing the smile on his face, I know I saved a family.";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "\"Mom, have you see, I made it.\"";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "\"I wish you be proud of me.\"";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "The End";
                yield return new WaitForSeconds(7f);
                MimeDia.text = "Design: \n Jiaxiang Mu  穆嘉翔\n Jiayu Shi  石家毓\n Moling Chen  陈茉菱\n Qiqing Zhang  张棋清\n Rong Sheng  盛荣 \n Yilun Wang  王轶伦";
                yield return new WaitForSeconds(7f);
                MimeDia.text = "CV: \n Jiaxiang Mu  穆嘉翔\n Jiayu Shi  石家毓\n Moling Chen  陈茉菱\n Qiqing Zhang  张棋清\n Rong Sheng  盛荣 \n Yilun Wang  王轶伦";
                yield return new WaitForSeconds(7f);
                MimeDia.text = "Program: \n Jiayu Shi  石家毓\n Moling Chen  陈茉菱\n Qiqing Zhang  张棋清\n Yilun Wang  王轶伦";
                yield return new WaitForSeconds(7f);
                MimeDia.text = "Sketch: \n Jiayu Shi  石家毓\n Moling Chen  陈茉菱\n Rong Sheng  盛荣";
                yield return new WaitForSeconds(7f);
                MimeDia.text = "Document: \n Jiaxiang Mu  穆嘉翔\n Rong Sheng  盛荣";
                yield return new WaitForSeconds(7f);
                MimeDia.text = "Copyright: \n Adobe Mixamo \n aigei 爱给网 \n freepd \n cgtrader \n ChinaZ 站长素材 \n Unity Assets Store";
                yield return new WaitForSeconds(7f);
                MimeDia.text = "Tools: \n Adobe Mixamo \n Unity \n Visual Studio \n Adobe Premiere \n FormatFactory \n Paint 3D";
                yield return new WaitForSeconds(7f);
                MimeDia.text = "Special Thanks: \n Chris Barney \n Rana Jahani \n &\n All the students in GSND6250";
                yield return new WaitForSeconds(7f);
                MimeDia.text = "Special Thanks: \n And \nYou";
                yield return new WaitForSeconds(7f);
                MimeDia.text = "Thank you for playing.";
                yield return new WaitForSeconds(10f);
                Application.Quit();
                CurrentScene++;
                break;
            case 4:
                //BGM.SetActive(true);
                MimeDia.text = "Hey Boiiii, You mother just Boomshakalaka";
                yield return new WaitForSeconds(3f);
                MimeDia.text = "Why so serious?";
                yield return new WaitForSeconds(3f);
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
