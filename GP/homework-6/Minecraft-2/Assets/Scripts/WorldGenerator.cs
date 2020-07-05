﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject grassVoxel;
    int lowerBound = -10;
    int upperBound = 0;
    void Awake() {
        for (int i = lowerBound; i <= upperBound; i++) {
            for (int j = lowerBound; j <= upperBound; j++) {
                CloneAndPlace(new Vector3(i, 0, j), grassVoxel);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CloneAndPlace(Vector3 newPosition, GameObject originalGameobject)
    {
        // Clone
        GameObject clone = (GameObject)Instantiate(originalGameobject, newPosition, Quaternion.identity);
        // Place
        clone.transform.position = newPosition;
        // Rename
        clone.name = "Voxel@" + clone.transform.position;
        clone.tag = "voxel";
        if (GameManager.isPencil) {
            clone.transform.Find("Top").GetComponent<Renderer>().material = GameManager.instance.TopPencil;
            clone.transform.Find("Front").GetComponent<Renderer>().material = GameManager.instance.SidePencil;
            clone.transform.Find("Back").GetComponent<Renderer>().material = GameManager.instance.SidePencil;
            clone.transform.Find("Left").GetComponent<Renderer>().material = GameManager.instance.SidePencil;
            clone.transform.Find("Right").GetComponent<Renderer>().material = GameManager.instance.SidePencil;
            clone.transform.Find("Bottom").GetComponent<Renderer>().material = GameManager.instance.BottomPencil;
        }
    }
}
