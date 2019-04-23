﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    private GameController gameControllerObj;

    void Start()
    {
        gameControllerObj = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        startPosition = transform.position;
    }

    void Update ()
    {
        if (gameControllerObj.winCondition == true)
        {
            if (scrollSpeed >= -15)
            {
                scrollSpeed -= Time.deltaTime;
            }
        }
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}

