using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject CGCamera;
    public GameObject ControlCamera;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeView()
    {
        CGCamera.SetActive(false);
        ControlCamera.SetActive(false);
        Player.SetActive(true);
    }
}
