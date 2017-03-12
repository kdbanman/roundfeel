using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickable : MonoBehaviour {

    public bool isSticky;
    public int maxStuck;

    public HashSet<GameObject> stuck = new HashSet<GameObject>();

    void OnCollisionEnter(Collision collision) {
        if (!isSticky || stuck.Count > maxStuck || stuck.Contains(collision.gameObject)) {
            return;
        }

        var stickable = collision.gameObject.GetComponent<Stickable>();
        if (stickable != null && stickable.isSticky) {
            Stick(stickable);
        }
    }

    void OnJointBreak(float breakForce) {
        Debug.Log("A joint has just been broken!, force: " + breakForce);
    }

    public void Stick(Stickable stickable) {
        stuck.Add(stickable.gameObject);

        var collisionDistance = Vector3.Distance(transform.position, stickable.gameObject.transform.position);

        var springJoint = gameObject.AddComponent<SpringJoint>();
        springJoint.damper = 1.5f;
        springJoint.spring = 0f;
        springJoint.enableCollision = true;
        springJoint.minDistance = 0f;
        springJoint.maxDistance = collisionDistance * 1.05f;
        springJoint.tolerance = 1f;


        springJoint.connectedBody = stickable.GetComponent<Rigidbody>();
    }
}
