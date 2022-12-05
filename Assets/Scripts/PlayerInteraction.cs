using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Ray ray;
    public TextMeshProUGUI SceneDia;
    public Camera myCamera;
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
    IEnumerator ClearDia(float a)
    {
        yield return new WaitForSeconds(a);
        SceneDia.text = "";
    }
}
