using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game Point collection logic
/// </summary>
public class PointLogic : MonoBehaviour {

    /// <summary>
    /// Collider Trigger for the game points
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            GameManager.Instance.points += 1;
            Destroy(this.gameObject);
        }
        
    }
}
