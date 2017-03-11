using UnityEngine;
using System.Collections;

public class PickupCollector : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Collectable") {
            Destroy(other.gameObject);
        }
    }
}
