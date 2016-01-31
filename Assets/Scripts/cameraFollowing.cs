using UnityEngine;
using System.Collections;

public class cameraFollowing : MonoBehaviour
{
    public Transform target;
    public float smooth = 3.0f;
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, transform.position.y, transform.position.z);
        print(newPos);
        transform.position = Vector3.Lerp(
            transform.position, newPos,
            Time.deltaTime * smooth);
    }

}