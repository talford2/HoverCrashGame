using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    public Transform Target;

    public float FollowDistance = 6;

    public float FollowHeight = 1;

    public float CamSpeed = 5f;



    void Start()
    {

    }

    void Update()
    {
        //Vector3.Lerp(transform.position, Target.position + Offset, Time.deltaTime);
    }

    //void FixedUpdate()
    //{
    //    transform.LookAt(Target);
    //    var targetPosition = Target.position + (FollowDistance * Target.forward * -1) + (FollowHeight * Target.up);
    //    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * CamSpeed);
    //}

    void LateUpdate()
    {
        transform.LookAt(Target);
        var targetPosition = Target.position + (FollowDistance * Target.forward * -1) + (FollowHeight * Target.up);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * CamSpeed);
    }
}
