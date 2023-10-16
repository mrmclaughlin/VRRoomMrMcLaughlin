using UnityEngine;
using UnityEngine.XR;

public class JoystickMovements : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform xrRig;

    void Update()
    {
        InputDevice deviceRight = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
		InputDevice deviceLeft = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        Vector2 primary2DAxisValue;
		Vector2 joystickYValue;
        if (deviceRight.TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxisValue))
        {
            // Move the XR Rig
            Vector3 direction = new Vector3(primary2DAxisValue.x, 0, primary2DAxisValue.y);
            xrRig.position += xrRig.rotation * direction * speed * Time.deltaTime;
        }
		
		
		if (deviceLeft.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickYValue))
            {
                // Move the XR Rig up and down based on joystick's Y-axis value
                Vector3 moveDirection = new Vector3(0, joystickYValue.y, 0);
                xrRig.position += moveDirection * speed * Time.deltaTime;
            }
		
		
    }
}
