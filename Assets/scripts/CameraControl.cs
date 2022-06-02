using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public IEnumerator CameraShakeZ()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+0.1f);
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
    }

    public IEnumerator CameraShakeY()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
        yield return new WaitForSeconds(0.05f);
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
    }

}
