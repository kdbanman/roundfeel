using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
	public float offsetScale;

    private Vector3 offset;
    private Vector3 lastPlayerPosition;

    void Start () {
        lastPlayerPosition = player.transform.position;
    }

    void LateUpdate () {
        var playerPositionDelta = player.transform.position - lastPlayerPosition;
		playerPositionDelta.Scale(new Vector3(offsetScale, 0, offsetScale));

        transform.position = transform.position + playerPositionDelta;

        lastPlayerPosition = player.transform.position;
    }
}
