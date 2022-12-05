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
            }
        }

    }

    private void CommunicateWithCry(RaycastHit raycastHit)
    {
        if (raycastHit.transform.CompareTag("Cry"))
        {
            
            SceneDia.text = "1111111111";
            StartCoroutine(ClearDia(5f));
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
        MimeDia.text = "1";
        yield return new WaitForSeconds(2f);
        MimeDia.text = "2";
        yield return new WaitForSeconds(2f);
        MimeDia.text = "3";
        yield return new WaitForSeconds(2f);
        MimeDia.text = "4";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
