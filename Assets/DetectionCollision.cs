using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class DetectionCollision : MonoBehaviour
{
    public GameObject actualObject;
    public GameObject[] childObjects;


    //private Vector3 initialPosition;
    //private Quaternion initialRotation;


    // Start is called before the first frame update
    void Start()
    {
        /*
        if (!attachTransform)
        {
            GameObject attachPoint = new GameObject("OffSet Grab Object");
            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        }
        else
        {
            initialPosition = transform.localPosition;
            initialRotation = transform.rotation;
        }*/
    }



   // float tailleVoxel = 0.1f;




    
    void Update()
    {
        /*
        foreach(GameObject child in childObjects)
        { 
            if (CheckCollision(actualObject, child))
            {
                Debug.Log("ha");
                actualObject.GetComponent<Renderer>().material.color = Color.blue;
            }
            else
            {
                actualObject.GetComponent<Renderer>().material.color = Color.white;
                Debug.Log("ho");

            }
            Debug.Log(childObjects);

        }*/
        
        foreach (GameObject child in childObjects)
        {
            Collider collider = child.GetComponent<Collider>();
            if (collider != null)
            {
                foreach (GameObject otherChild in childObjects)
                {
                    if (otherChild != child && otherChild.GetComponent<Collider>() != null)
                    {
                        Bounds bounds1 = new Bounds(child.transform.position, child.GetComponent<Renderer>().bounds.size);
                        Bounds bounds2 = new Bounds(otherChild.transform.position, otherChild.GetComponent<Renderer>().bounds.size);
                        if (bounds1.Intersects(bounds2))
                        {
                            Debug.Log("Hello");
                            child.GetComponent<Renderer>().material.color = Color.blue;
                        }
                        else
                        {
                            Debug.Log("hiii");
                            child.GetComponent<Renderer>().material.color = Color.white;
                        }
                        /*if (Vector3.Distance(child.transform.position, otherChild.transform.position) < 0.1f)
                        {
                            Debug.Log("Hello");
                            child.GetComponent<Renderer>().material.color = Color.blue;
                        }
                        else
                        {
                            Debug.Log("hiii");
                            child.GetComponent<Renderer>().material.color = Color.white;
                        }*/
                        /*
                            if (Physics.ComputePenetration(collider, child.transform.position, child.transform.rotation, otherChild.GetComponent<Collider>(), otherChild.transform.position, otherChild.transform.rotation, out Vector3 direction, out float distance))
                        {
                            child.GetComponent<Renderer>().material.color = Color.blue;
                        }
                        else
                        {
                            child.GetComponent<Renderer>().material.color = Color.white;
                        }*/
                    }
                }
            }
        }

    }
    /*
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("fragment"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
    }
    */
    bool CheckCollision(GameObject obj1, GameObject obj2)
    {
        float distance = Vector3.Distance(obj1.transform.position, obj2.transform.position);
        if (distance < 0.001f)
        {
            return true; 
        }
        return false;

    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == actualObject)
        {
            Renderer renderer = actualObject.GetComponent<Renderer>();
            renderer.material.color = Color.blue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == actualObject)
        {
            Renderer renderer = actualObject.GetComponent<Renderer>();
            renderer.material.color = Color.white;
        }
    }*/
    /*
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRDirectInteractor)
        {
            attachTransform.position = args.interactorObject.transform.position;
            attachTransform.rotation = args.interactorObject.transform.rotation;
        }
        else
        {
            attachTransform.position = initialPosition;
            attachTransform.rotation = initialRotation;
        }

        base.OnSelectEntered(args);
    }*/
}

