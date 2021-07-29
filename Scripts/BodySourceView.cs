using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class BodySourceView : MonoBehaviour 
{
    public BodySourceManager mBodySourceManager;
    public GameObject mJointObject;
  

    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
    private List<JointType> _joints = new List<JointType>
    {
        //JointType.HandLeft,
        JointType.HandRight,
    };
    
    
    void Update()
    {
        // Get Kinect Data
        Body[] data = mBodySourceManager.GetData();
        if(data == null) 
            return;

        List<ulong> trackedIds = new List<ulong>();
            
        foreach(var body in data)
        {
            if(body == null)
                continue;

            if(body.IsTracked)
                trackedIds.Add(body.TrackingId);
        }


        // Delete Kinect Bodies
        List<ulong> knownIds = new List<ulong>(mBodies.Keys);
        foreach(ulong trackingId in knownIds)
        {
            if(!trackedIds.Contains(trackingId))
            {
                // Destroy Body Objects
                Destroy(mBodies[trackingId]);

                // Remove From List
                mBodies.Remove(trackingId);
            }
            
        }

        // Create Kinect Bodies
        foreach(var body in data)
        {
            if(body == null)
                continue;

            if(body.IsTracked)
            {
                if(!mBodies.ContainsKey(body.TrackingId))
                {
                    mBodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                    DontDestroyOnLoad(mBodies[body.TrackingId]);
                }    
                // Update position
                UpdateBodyObject(body, mBodies[body.TrackingId]);
            }
        }

    }
    
    private GameObject CreateBodyObject(ulong id)
    {
        GameObject body = new GameObject("Body:" + id);
        
        // Create Joints
        foreach(JointType joint in _joints)
        {
            // Create Object
            GameObject newJoint = Instantiate(mJointObject);
            newJoint.name = joint.ToString();

            // Parent Body
            newJoint.transform.parent = body.transform;
        }
        
        return body;
    }
    
    private void UpdateBodyObject(Body body, GameObject bodyObject)
    {
        // Update Joints
        foreach(JointType _joint in _joints)
        {
            // Get new target position
            Joint sourceJoint = body.Joints[_joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);
            targetPosition.z = 0;

            // Get Joint, set new position
            Transform jointObject = bodyObject.transform.Find(_joint.ToString());
            jointObject.position = targetPosition;
        }
    }
    
    private static Vector3 GetVector3FromJoint(Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}
