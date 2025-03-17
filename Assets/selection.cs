using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.UIElements;
using UnityEditor;
using Oculus.Interaction;
using UnityEngine.EventSystems;
using OculusSampleFramework;
using Unity.VisualScripting;

public class selection : MonoBehaviour
{
    List<UnityEngine.XR.InputDevice> inputDevices = new List<UnityEngine.XR.InputDevice>();
    public GameObject[] childObjects;
    public Transform parent;
    public GameObject gameObjet;
    public GameObject objet;

    private XRController xr;
    void Start()
    {
        xr = (XRController)GameObject.FindObjectOfType(typeof(XRController));
    }

    // Update is called once per frame
    void Update()
    {
        bool pressedA;
        bool pressedB;
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
        foreach (UnityEngine.XR.InputDevice device in inputDevices)
        {
            if (device.characteristics.HasFlag(InputDeviceCharacteristics.Right))
            {
                if (device.IsPressed(InputHelpers.Button.PrimaryButton, out pressedA) && pressedA)
                {
                    objet.SetActive(true);
                    gameObjet.transform.position = objet.transform.position;
                    foreach (GameObject obj in childObjects)
                    {
                        obj.transform.SetParent(parent);
                        pressedA = false;
                        //pressedB = true;
                    }
                    Debug.Log("hellooooo");
                }
                if (device.IsPressed(InputHelpers.Button.SecondaryButton, out pressedB) && pressedB)
                {
                    objet.SetActive(false);
                    foreach (GameObject obj in childObjects)
                    {
                        obj.transform.SetParent(null);

                    }
                    pressedB = false;
                    //pressedA = true;
                    Debug.Log("gsgs");
                }
            }
            /*foreach (GameObject o in childObjects) 
            { 
                for (int i = 0; i < childObjects.Length; i++)
                {
                    for (int j = i + 1; j < childObjects.Length; j++)
                    {
                        if (collision(childObjects[i], childObjects[j]))
                        {
                            childObjects[i].GetComponent<Renderer>().material.color = Color.blue;
                        }
                        else
                        {
                            childObjects[i].GetComponent<Renderer>().material.color = Color.white;
                        }

                    }
                }
            }*/
            
//            //CheckCollision(obj);
        }
    }
    /*
    bool collision(GameObject obj1, GameObject obj2)
    {
        Collider collider1 = obj1.GetComponent<Collider>();
        Collider collider2 = obj2.GetComponent<Collider>();
        return collider1.bounds.Intersects(collider2.bounds);
    }

    void CheckCollision(GameObject obj)
    {
        
        foreach (GameObject o in childObjects)
        {
            float distance = Vector3.Distance(obj.transform.position, o.transform.position);
            if (distance < 0.001f)
            {
                obj.GetComponent<Renderer>().material.color = Color.blue;
            }
            else
            {
                obj.GetComponent<Renderer>().material.color = Color.white;
            }
                
            
        }
        
    }

    
    */


}
