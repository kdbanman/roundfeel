using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    public float rotationRate = 1.0f;

    void Update () {
        transform.Rotate(new Vector3( 10, 20, 40) * rotationRate * Time.deltaTime);
    }
}
