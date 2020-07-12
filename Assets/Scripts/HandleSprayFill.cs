﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleSprayFill : MonoBehaviour
{

    [SerializeField] float sprayCapacity = 1f;
    [SerializeField] float sprayAdjust = 10f;

    public bool sprayOn = false;


    // Start is called before the first frame update
    void Start()
    {
        sprayCapacity = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = sprayCapacity;
        handleValue();
        handleMouseUp();
        handleSprayFill();
    }

    private void handleSprayFill()
    {
        if (!sprayOn && sprayCapacity < 1f)
        {
            sprayCapacity += Time.deltaTime / 4f;
        }
    }

    private void handleMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            sprayOn = false;
        }
    }

    private void handleValue()
    {
        if (sprayOn && sprayCapacity > 0f)
        {
            sprayCapacity -= Time.deltaTime;
        }
    }
}
