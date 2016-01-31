using UnityEngine;
using System.Collections;

public class cameraFollowing : MonoBehaviour
{
    public WizardController target;
    public float smooth = 3.0f;
    void Update()
    {
        Vector3 newPos = new Vector3(System.Math.Min(System.Math.Max(target.wizardX, target.minCameraX), target.maxCameraX), transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(
            transform.position, newPos,
            Time.deltaTime * smooth);
    }

}