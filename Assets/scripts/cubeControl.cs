using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeControl : MonoBehaviour
{
    public PlayerController Player;
    public GameObject CubeHolder;
    public GameObject Cube;
    public GameObject PlusOne;
    public CameraControl CameraScript;

    void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.tag == "Cube")
        {
            PlusCube(collision);
        }
        else if(collision.gameObject.tag == "Wall")
        {
            MinusCube(collision);
        }        
    }

    private void PlusCube(Collision collision)
    {
        GameObject newCube = Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);
        newCube.transform.SetParent(CubeHolder.transform);
        newCube.name = "newCube";

        GameObject plusOne = Instantiate(PlusOne, new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z), Quaternion.identity);
        plusOne.name = "plusOne";
        plusOne.transform.SetParent(collision.gameObject.transform.parent);

        Destroy(collision.gameObject);
        StartCoroutine(Player.MovePlayerUpDown(true));
        StartCoroutine(CameraScript.CameraShakeY());
    }

    private void MinusCube(Collision collision)
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        gameObject.transform.SetParent(collision.gameObject.transform);
        StartCoroutine(Player.MovePlayerUpDown(false));
        StartCoroutine(CameraScript.CameraShakeZ());
        Vibrate();
    }

    private static void Vibrate()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
	Handheld.Vibrate();
#else
        Debug.Log("Vibrate");
#endif
    }
}
