using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCam;
    public Transform myPortal;
    public Transform playerPortal;
    public float rotationOffset = 0f;

    void Update()
    {
        
        Vector3 playerOffsetFromPortal = playerCam.position - playerPortal.position;
        transform.position = myPortal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(myPortal.rotation, playerPortal.rotation) + rotationOffset;

        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCam.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
