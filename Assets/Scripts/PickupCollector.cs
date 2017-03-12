using UnityEngine;
using System.Collections;

public class PickupCollector : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        var collectable = other.gameObject.GetComponent<Collectable>();
        if (collectable != null) {
            var score = GameObject.FindWithTag("Player").GetComponent<Score>();
            score.AddPoints(collectable.Collect());

            other.gameObject.AddComponent<PickupCollector>();
        }
    }
}
