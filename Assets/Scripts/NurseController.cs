using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseController : MonoBehaviour
{
    public Animator NurseAnim;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeAnimState()
    {
        NurseAnim.SetTrigger("Reach");
    }
    public void StartMimeInAnim()
    {
        Player.GetComponent<PlayerInteraction>().StartMime(2);
    }
}
