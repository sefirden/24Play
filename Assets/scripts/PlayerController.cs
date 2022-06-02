using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject CubeHolder;
    public uiControl ui;
    public CameraControl CameraScript;
    public bool EndGame;
    public GameObject Trail;
    public GameObject TrackController;
    public Transform Parent;


    void Start()
    {
        Parent = TrackController.transform.GetChild(0).transform;

    }
    void Update()  
    {
        if (EndGame != true)
        {
            GameObject newTrail = Instantiate(Trail, new Vector3(transform.position.x, Trail.transform.position.y, transform.position.z), Quaternion.identity);
            newTrail.transform.SetParent(Parent);
        }

        if (Input.GetMouseButton(0) && EndGame!=true)
        {
            float halfSW = Screen.width * 0.5f;
            float delta = Input.mousePosition.x - halfSW;
            float k = delta / halfSW;
            var p = transform.position;
            p.x = speed * k;
            if (p.x < -2)
                p.x = -2;
            else if(p.x > 2)
                p.x = 2;
            transform.position = p;

            float CameraX = CameraScript.gameObject.transform.position.x + (p.x * 0.025f);
            if (CameraX < 3f)
                CameraX = 3f;
            else if (CameraX > 4)
                CameraX = 4;
            CameraScript.gameObject.transform.position = new Vector3(CameraX, CameraScript.gameObject.transform.position.y, CameraScript.gameObject.transform.position.z);
        }
    }

    public IEnumerator MovePlayerUpDown(bool up)
    {
        if (up)
        {
            transform.position = new Vector3(transform.position.x, CubeHolder.transform.childCount + 1f, transform.position.z);
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Jump");
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
        }
        else
        {
            if (CubeHolder.transform.childCount == 0) //конец игры
            {
                gameObject.GetComponentInChildren<Rigidbody>().isKinematic = false;
                EndGame = true;
                yield return new WaitForSeconds(0.5f);
                ui.EndGame();
                Time.timeScale = 0f;
            }

            yield return new WaitForSeconds(0.2f);
            Vector3 startPosition = transform.position;
            Vector3 endPosition = new Vector3(transform.position.x, CubeHolder.transform.childCount + 1f, transform.position.z);
            float step; 
            float moveTime = 0;
            float speed = 10;


            step = (speed / (startPosition - endPosition).magnitude) * Time.fixedDeltaTime;

            while (moveTime <= 1.0f)
            {
                moveTime += step;
                transform.position = Vector3.Lerp(startPosition, endPosition, moveTime);
                yield return new WaitForFixedUpdate();
            }
            transform.position = endPosition;


            Parent = TrackController.transform.GetChild(1).transform;

            StartCoroutine(CameraScript.CameraShakeZ());
        }


    }
}
