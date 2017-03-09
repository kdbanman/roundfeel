using UnityEngine;
using System.Collections;

public class PickupCreator : MonoBehaviour {

    public Object pickupPrefab;
    public int numPickups;
    public float pickupRadius;

    void Start () {
        for (int i = 0; i < numPickups; i++) {

            var rads = 2 * Mathf.PI * (float)i / (float)numPickups;

            GameObject obj = (GameObject)Instantiate(pickupPrefab);

            var x = pickupRadius * Mathf.Cos(rads);
            var z = pickupRadius * Mathf.Sin(rads);

            obj.transform.position = new Vector3(x, 0.25f, z);
            obj.transform.rotation = Random.rotation;
            obj.GetComponent<Rotator>().rotationRate = Random.Range(0.8f, 1.9f);
        }
    }

}
