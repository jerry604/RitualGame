using UnityEngine;
using System.Collections;

public class ItemActiveandNot : MonoBehaviour {
	public GameObject item;
	void Start () {
		item.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
