using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyRotate : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            LookPlayer();
        
        
    }
    private void LookPlayer()
    {
        this.transform.LookAt(new Vector3(Player.transform.position.x, this.transform.position.y, Player.transform.position.z));
    }
}
