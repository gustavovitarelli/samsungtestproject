using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLogic : MonoBehaviour {

    public bool hit = false;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(!hit) 
                GameManager.Instance.xp = 0;
            hit = true;
            Destroy(this.gameObject);
        }

    }
}
