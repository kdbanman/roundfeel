using UnityEngine;
using System.Collections;

public class PickupCreator : MonoBehaviour {

    public Object pickupPrefab;
    public Material deadMaterial;

    public float pickupHeight;
    public float pickupSeparation;
    public float innerPickupRadius;
    public float outerPickupRadius;

    void Start () {
        float pickupRadius = innerPickupRadius;
        while (pickupRadius < outerPickupRadius) {
            float circumference = 2 * Mathf.PI * pickupRadius;
            int numPickups = (int)Mathf.Floor(circumference / pickupSeparation);

            for (int i = 0; i < numPickups; i++) {

                var rads = 2 * Mathf.PI * (float)i / (float)numPickups;

                GameObject obj = (GameObject)Instantiate(pickupPrefab);

                var x = pickupRadius * Mathf.Cos(rads);
                var z = pickupRadius * Mathf.Sin(rads);

                obj.transform.position = new Vector3(x, pickupHeight, z);
                obj.transform.rotation = Random.rotation;
                obj.GetComponent<Collectable>().rotationRate = Random.Range(0.8f, 1.9f);
                obj.GetComponent<Collectable>().deadMaterial = deadMaterial;
            }

            pickupRadius += pickupSeparation;
        }
    }
}
