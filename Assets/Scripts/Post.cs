using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post : MonoBehaviour
{
    public GameObject PostPic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pickup()
    {
        PostPic.SetActive(true);
        PostManager.postpicked = true;
        StartCoroutine(Killyourself());
        this.GetComponent<MeshRenderer>().enabled = false;
    }
    IEnumerator Killyourself ()
    {
        yield return new WaitForSecondsRealtime(3f);
        PostPic.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
