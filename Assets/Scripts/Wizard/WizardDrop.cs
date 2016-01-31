using UnityEngine;
using System.Collections;

public class WizardDrop : MonoBehaviour {
	public Rigidbody 
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("f"))
		{
			//The Bullet instantiation happens here.
			GameObject Temporary_Item_Handler;
			Temporary_Item_Handler = Instantiate(item,wiz.transform.position,wiz.transform.rotation) as GameObject;

			//Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
			//This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
			wiz.transform.Rotate(Vector3.left * 90);

			//Retrieve the Rigidbody component from the instantiated Bullet and control it.
			Rigidbody Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Item_Handler.GetComponent<Rigidbody>();

			//Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
			Temporary_RigidBody.AddForce(transform.forward * 10);
			/*
			//Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
			Destroy(Temporary_Bullet_Handler, 10.0f);*/
		}
	}
}
