using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
    public float rotationRate = 1.0f;
    public Material deadMaterial;

    private bool collected = false;

    void Setup () {
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = true;
    }

    void Update () {
        if (!collected) {
            transform.Rotate(new Vector3( 10, 20, 40) * rotationRate * Time.deltaTime);
        }
    }

    public int Collect () {
        collected = true;

        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.isKinematic = false;

        var collider = GetComponent<Collider>();
        collider.isTrigger = false;

        GetComponent<Renderer>().material = deadMaterial;

        return 8;
    }
}
