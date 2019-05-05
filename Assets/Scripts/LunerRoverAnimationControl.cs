using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunerRoverAnimationControl : MonoBehaviour
{
    [SerializeField] Transform antenna, radar;
    [SerializeField] float rpmAntenna, rmpRadar;
    [SerializeField] Transform wheelHubLeft, wheelHubRight;
    [SerializeField] Transform wheelLeft, wheelRight;
    [SerializeField] Transform hubLeftFrontJoint, hubLeftRearJoint, hubRightFrontJoint, hubRightRearJoint;
    [SerializeField] Transform barLeftFrontJoint, barLeftRearJoint, barRightFrontJoint, barRightRearJoint;
    [SerializeField] Transform centerOfGravity;

    [SerializeField] Rigidbody rb;

    public float turnRotationDegrees = 0f;
    public float maxTurnAngle = 22f;

    // Start is called before the first frame update
    void Start()
    {
        //rb.centerOfMass = centerOfGravity.position;
    }    

    void UpdateWheelRotation()
    {
        // Limit turn radius
        turnRotationDegrees = Mathf.Clamp(turnRotationDegrees, -maxTurnAngle, maxTurnAngle);

        // Set wheel angle
        wheelHubRight.transform.localRotation = Quaternion.Euler(0, turnRotationDegrees, 0);
        wheelHubLeft.transform.rotation = wheelHubRight.transform.rotation;

        // Update steering bar position
        barLeftFrontJoint.position = hubLeftFrontJoint.position;
        barLeftRearJoint.position = hubLeftRearJoint.position;
        barRightFrontJoint.position = hubRightFrontJoint.position;
        barRightRearJoint.position = hubRightRearJoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWheelRotation();
        
        radar.transform.Rotate(6.0f * rmpRadar * Time.deltaTime, 0, 0);
        antenna.transform.Rotate(0, 6.0f * rpmAntenna * Time.deltaTime, 0);
    }
}