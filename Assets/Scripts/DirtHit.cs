using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        // make sure the player has this tag
        if (collider.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

}
