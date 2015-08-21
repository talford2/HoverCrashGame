using UnityEngine;
using System.Collections;

public class SelfDestructor : MonoBehaviour
{
    public float TimeToDestruct = 1f;

    void Update()
    {
        TimeToDestruct -= Time.deltaTime;
        if (TimeToDestruct <= 0)
        {
            Destroy(gameObject);
        }
    }
}
