using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float thrust;

    void Start () {
    }

    void Update () {
    }

    void FixedUpdate () {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        var body = GetComponent<Rigidbody>();

        body.AddForce(moveHorizontal * thrust, 0, moveVertical * thrust);
    }
}
