using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class SelectionInteraction : MonoBehaviour
{
    [SerializeField] private GameObject actualGameObject;

    [SerializeField] private GameObject leftController;
    [SerializeField] private GameObject rightController;

    private Vector3? previousPositionLeft;
    private Vector3? previousPositionRight;

    private InputActionAsset inputs;
    [SerializeField] private InputActionManager inputActionManager;

    // Awake when left or right grip button is pressed
    private void Awake()
    {
        inputs = inputActionManager.actionAssets[0];
        InputActionMap leftAction = inputs.FindActionMap("XRI LeftHand Interaction");
        InputActionMap rightAction = inputs.FindActionMap("XRI RightHand Interaction");
        leftAction.FindAction("Select Value").started += GripVolumeLeft;
        leftAction.FindAction("Select Value").canceled += GripVolumeLeft;
        rightAction.FindAction("Select Value").started += GripVolumeRight;
        rightAction.FindAction("Select Value").canceled += GripVolumeRight;
    }

    // Set previous position of left controller
    private void GripVolumeLeft(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started || callbackContext.performed )
        {
            previousPositionLeft = leftController.transform.position;
        }
        if (callbackContext.canceled )
        {
            previousPositionLeft = null;
        }
    }

    // Set previous position of right controller
    private void GripVolumeRight(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started || callbackContext.performed)
        {
            previousPositionRight = rightController.transform.position;
        }
        if (callbackContext.canceled)
        {
            previousPositionRight = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (previousPositionLeft.HasValue && previousPositionRight.HasValue)
        {
            // Movement of the selected object
            Vector3 currentPosition = 0.5f * (leftController.transform.position + rightController.transform.position);
            Vector3 previousPosition = 0.5f * (previousPositionLeft.Value + previousPositionRight.Value);
            Vector3 movement = currentPosition - previousPosition;
            actualGameObject.transform.position += movement;

            // Rotation of the selected object
            Vector3 currentLine = leftController.transform.position - rightController.transform.position;
            Vector3 previousLine = previousPositionLeft.Value - previousPositionRight.Value;
            Vector3 axis = Vector3.Cross(previousLine, currentLine);
            if (axis.magnitude > Mathf.Epsilon)
            {
                float angle = Vector3.Angle(currentLine, previousLine);
                actualGameObject.transform.RotateAround(actualGameObject.transform.position, axis, angle);
            }

            // Change scale of the selected object
            float scaleChange = currentLine.magnitude / previousLine.magnitude;
            actualGameObject.transform.localScale *= scaleChange;

            // Set the new previous position of left & right controllers
            if (previousPositionLeft.HasValue)
            {
                previousPositionLeft = leftController.transform.position;
            }
            if (previousPositionRight.HasValue)
            {
                previousPositionRight = rightController.transform.position;
            }
        }
    }
}
