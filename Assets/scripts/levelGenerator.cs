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
        GameObject newTrack = Instantiate(TrackGround, new Vector3(TrackGround.transform.position.x, TrackGround.transform.position.y, TrackGround.transform.position.z + 30f), Quaternion.identity); //������� ������ �����, ������� ����� ������ �� ������ ���� � ������� ������������
        newTrack.transform.parent = this.transform; //����������� �������
        newTrack.name = "newTrack"; //����������� ���

        GameObject newTrack2 = Instantiate(TrackGround, new Vector3(TrackGround.transform.position.x, TrackGround.transform.position.y, TrackGround.transform.position.z + 60f), Quaternion.identity); //������� ������ �����, ������� ����� ������ �� ������ ���� � ������� ������������
        newTrack2.transform.parent = this.transform; //����������� �������
        newTrack2.name = "newTrack2"; //����������� ���
        lastTrack = newTrack2;
    }

    public void NewTrack()
    {
        GameObject newTrack = Instantiate(TrackGround, new Vector3(TrackGround.transform.position.x, TrackGround.transform.position.y, lastTrack.transform.position.z + 30f), Quaternion.identity); //������� ������ �����, ������� ����� ������ �� ������ ���� � ������� ������������
        newTrack.transform.parent = this.transform; //����������� �������
        newTrack.name = "newTrack"; //����������� ���

        lastTrack = newTrack;
    }
}
