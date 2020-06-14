﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HandPresence : MonoBehaviour
{
    public List<GameObject> controllers;
    public InputDeviceCharacteristics controllerCharacteristics;
    public bool showController = false;

    private InputDevice targetDevice;
    public GameObject handModelPrefab;
    private GameObject spawnedHandModel;
    private GameObject spawnedController;

    
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllers.Find(controller => controller.name == targetDevice.name);

            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                //not found --switch to default controller
                spawnedController = Instantiate(controllers[0], transform);
            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);

        if (showController)
        {
            spawnedHandModel.SetActive(false);
            spawnedController.SetActive(true);
        }
        else
        {
            spawnedController.SetActive(false);
            spawnedHandModel.SetActive(true);
        }


        
    }
}
