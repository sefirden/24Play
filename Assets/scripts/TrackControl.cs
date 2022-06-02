using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackControl : MonoBehaviour
{
    public Vector3 direction;
    public float acceleration;
    public Rigidbody rb;
    private levelGenerator LevelGenerator;
    public GameObject Cube;
    public GameObject Wall;
    public GameObject Trail;
    private PlayerController Player;


    void Awake()
    {
        Player = FindObjectOfType<PlayerController>();
        //Trail.transform.position = new Vector3(Player.transform.position.x, Trail.transform.position.y, Player.transform.position.z);
        rb.velocity = direction.normalized * acceleration;
        int cubeCount;
        LevelGenerator = FindObjectOfType<levelGenerator>();
        cubeCount = UnityEngine.Random.Range(2, 4);
        GenerateCube(cubeCount);
        GenerateWall();
    }

    private void GenerateWall()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < UnityEngine.Random.Range(2, 6); j++)
            { 
            GameObject newWall = Instantiate(Wall, new Vector3(transform.position.x - 2f + i, 2.5f+j, transform.position.z + 14.5f), Quaternion.identity); //создаем объект цифры, которая берет префаб из списка дотс и нужными координатами
            newWall.transform.parent = this.transform; //присваиваем позицию
            newWall.name = "newWall"; //присваиваем имя
            }
        }
    }

    private void GenerateCube(int cubeCount)
    {
        for (int i = -1; i < cubeCount; i++)
        {
            GameObject newCube = Instantiate(Cube, new Vector3(transform.position.x + (UnityEngine.Random.Range(-1, 2)*1.5f), 2.5f, transform.position.z+i*3f), Quaternion.identity); //создаем объект цифры, которая берет префаб из списка дотс и нужными координатами
            newCube.transform.parent = this.transform; //присваиваем позицию
            newCube.name = "newCube"; //присваиваем имя
        }
    }

    void FixedUpdate()
    {
        if(gameObject.transform.position.z < -35f)
        {
            LevelGenerator.NewTrack();
            Destroy(gameObject);
        }
    }
}
