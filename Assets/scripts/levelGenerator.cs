using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{

    public GameObject TrackGround;
    private GameObject lastTrack;

    void Awake()
    {
        BaseTrack();
    }


    public void BaseTrack()
    {
        GameObject newTrack = Instantiate(TrackGround, new Vector3(TrackGround.transform.position.x, TrackGround.transform.position.y, TrackGround.transform.position.z + 30f), Quaternion.identity); //создаем объект цифры, которая берет префаб из списка дотс и нужными координатами
        newTrack.transform.parent = this.transform; //присваиваем позицию
        newTrack.name = "newTrack"; //присваиваем имя

        GameObject newTrack2 = Instantiate(TrackGround, new Vector3(TrackGround.transform.position.x, TrackGround.transform.position.y, TrackGround.transform.position.z + 60f), Quaternion.identity); //создаем объект цифры, которая берет префаб из списка дотс и нужными координатами
        newTrack2.transform.parent = this.transform; //присваиваем позицию
        newTrack2.name = "newTrack2"; //присваиваем имя
        lastTrack = newTrack2;
    }

    public void NewTrack()
    {
        GameObject newTrack = Instantiate(TrackGround, new Vector3(TrackGround.transform.position.x, TrackGround.transform.position.y, lastTrack.transform.position.z + 30f), Quaternion.identity); //создаем объект цифры, которая берет префаб из списка дотс и нужными координатами
        newTrack.transform.parent = this.transform; //присваиваем позицию
        newTrack.name = "newTrack"; //присваиваем имя

        lastTrack = newTrack;
    }
}
