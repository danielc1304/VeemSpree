using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class InputManager : MonoBehaviour
{
    GenericXR_Controller inputActions;
    [SerializeField] Vector2 min_maxThreshold = new Vector2(0.1f, 0.9f);
    [SerializeField] Gun leftGun;
    [SerializeField] Gun rightGun;

    /*
     * Left Hand Grip Events
     */

    public static UnityEvent OnGripLeftPressed = new UnityEvent();
    public static UnityEvent<float> OnGripLeftUpdated = new UnityEvent<float>();
    public static UnityEvent OnGripLeftReleased = new UnityEvent();

    /*
     * Left Hand Trigger Events
     */

    public static UnityEvent OnTriggerLeftPressed = new UnityEvent();
    public static UnityEvent<float> OnTriggerLeftUpdated = new UnityEvent<float>();
    public static UnityEvent OnTriggerLeftReleased = new UnityEvent();

    /*
     * Right Hand Grip Events
     */

    public static UnityEvent OnGripRightPressed = new UnityEvent();
    public static UnityEvent<float> OnGripRightUpdated = new UnityEvent<float>();
    public static UnityEvent OnGripRightReleased = new UnityEvent();

    /*
     * Right Hand Trigger Events
     */

    public static UnityEvent OnTriggerRightPressed = new UnityEvent();
    public static UnityEvent<float> OnTriggerRightUpdated = new UnityEvent<float>();
    public static UnityEvent OnTriggerRightReleased = new UnityEvent();

    /*
     * Right Hand Trigger Events
     */

    float leftGripValue;
    float rightGripValue;
    float leftTriggerValue;
    float rightTriggerValue;

    bool leftGripPressed;
    bool rightGripPressed;
    bool leftTriggerPressed;
    bool rightTriggerPressed;

    /*
     * INIT
     */
    private void Awake()
    {
        inputActions = new GenericXR_Controller();
        inputActions.RightController.Grip.performed += PressGrip_Right;
        inputActions.RightController.Trigger.performed += PressTrigger_Right;
        inputActions.LeftController.Grip.performed += PressGrip_Left;
        inputActions.LeftController.Trigger.performed += PressTrigger_Left;
        inputActions.Enable();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    private void OnDestroy()
    {
        inputActions.Dispose();
    }

    /*
     * INPUT HANDLERS
     */


    private void PressGrip_Right(InputAction.CallbackContext obj)
    {
        rightGripValue = obj.ReadValue<float>();
        if (rightGripValue > min_maxThreshold.x && rightGripValue < min_maxThreshold.y)
        {
            OnGripRightUpdated.Invoke(rightGripValue);
        }
        if (!rightGripPressed && rightGripValue > min_maxThreshold.y)
        {
            OnGripRightPressed.Invoke();
            rightGripPressed = true;
            Debug.Log("Righ Grip Pressed");
        }
        if (rightGripPressed && rightGripValue < min_maxThreshold.x)
        {
            OnGripRightReleased.Invoke();
            rightGripPressed = false;
            Debug.Log("Righ Grip Released");
        }
    }

    private void PressTrigger_Right(InputAction.CallbackContext obj)
    {
        rightTriggerValue = obj.ReadValue<float>();
        if (rightTriggerValue > min_maxThreshold.x && rightTriggerValue < min_maxThreshold.y)
        {
            OnTriggerRightUpdated.Invoke(rightTriggerValue);
        }
        if (!rightTriggerPressed && rightTriggerValue > min_maxThreshold.y)
        {
            OnTriggerRightPressed.Invoke();
            rightTriggerPressed = true;
            rightGun.doShoot();
            Debug.Log("Righ Trigger Pressed");
        }
        if (rightTriggerPressed && rightTriggerValue < min_maxThreshold.x)
        {
            OnTriggerRightReleased.Invoke();
            rightTriggerPressed = false;
            Debug.Log("Righ Trigger Released");
        }
    }

    private void PressGrip_Left(InputAction.CallbackContext obj)
    {
        leftGripValue = obj.ReadValue<float>();
        if (leftGripValue > min_maxThreshold.x && leftGripValue < min_maxThreshold.y)
        {
            OnGripLeftUpdated.Invoke(leftGripValue);
        }
        if (!leftGripPressed && leftGripValue > min_maxThreshold.y)
        {
            OnGripLeftPressed.Invoke();
            leftGripPressed = true;
            Debug.Log("Left Grip Pressed");
        }
        if (leftGripPressed && leftGripValue < min_maxThreshold.x)
        {
            OnGripLeftReleased.Invoke();
            leftGripPressed = false;
            Debug.Log("Left Grip Released");
        }
    }

    private void PressTrigger_Left(InputAction.CallbackContext obj)
    {
        leftTriggerValue = obj.ReadValue<float>();
        if (leftTriggerValue > min_maxThreshold.x && leftTriggerValue < min_maxThreshold.y)
        {
            OnTriggerLeftUpdated.Invoke(leftTriggerValue);
        }
        if (!leftTriggerPressed && leftTriggerValue > min_maxThreshold.y)
        {
            OnTriggerLeftPressed.Invoke();
            leftTriggerPressed = true;
            Debug.Log("Left Trigger Pressed");
            leftGun.doShoot();
        }
        if (leftTriggerPressed && leftTriggerValue < min_maxThreshold.x)
        {
            OnTriggerLeftReleased.Invoke();
            leftTriggerPressed = false;
            Debug.Log("Left Trigger Released");
        }
    }

}
