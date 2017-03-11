using UnityEngine;
using System.Collections;

public class PickupCollector : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        var collectable = other.gameObject.GetComponent<Collectable>();
        if (collectable != null) {
            collectable.Collect();
        }
    }
}
