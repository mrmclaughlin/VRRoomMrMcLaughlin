using UnityEngine;
using UnityEngine.XR;

public class JoystickMovements : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform xrRig;

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        Vector2 primary2DAxisValue;

        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxisValue))
        {
            // Move the XR Rig
            Vector3 direction = new Vector3(primary2DAxisValue.x, 0, primary2DAxisValue.y);
            xrRig.position += xrRig.rotation * direction * speed * Time.deltaTime;
        }
    }
}
