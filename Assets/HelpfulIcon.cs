using UnityEngine;
using System.Collections;

public class HelpfulIcon : MonoBehaviour {
	public cameraFollowing camera;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(camera.transform.position.x - 8, camera.transform.position.y + 8, -1);
	}
}
