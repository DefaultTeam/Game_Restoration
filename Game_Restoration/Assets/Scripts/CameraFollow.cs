using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private float speed = 3;



    [SerializeField]
    private float MinY = 0;
    [SerializeField]
    private float MinX = 1000;
    [SerializeField]
    private float MaxX = 3;
    [SerializeField]
    private float MaxY = 0;

    public Transform target;

    Vector3 volocity = Vector3.zero;

    public float smoothtime = 0.15f;

    //private void Awake()
    //{
    //    if (!target)
    //        target = FindObjectOfType<Player>().tranform;
    //}

    private void FixedUpdate()
    {
        Vector3 position = target.position;
        position.z = -10;
        if (position.x > MinX && position.x < MaxX)// && position.y > MinY && position.y < MaxY)
            position.x = Mathf.Clamp(position.x, MinX, MaxX);
        else if(position.x <= MinX)
            position.x = Mathf.Clamp(position.x, MinX, position.x);
        else if (position.x >= MaxX)
            position.x = Mathf.Clamp(position.x, position.x,MaxX);

        if (position.y > MinY && position.y < MaxY)// && position.y > MinY && position.y < MaxY)
            position.y = Mathf.Clamp(position.y, MinY, MaxY);
        else if (position.y <= MinY)
            position.y = Mathf.Clamp(position.y, MinY, position.y);
        else if (position.y >= MaxY)
            position.y = Mathf.Clamp(position.y, position.y, MaxY);
        transform.position = Vector3.SmoothDamp(transform.position, position, ref volocity, smoothtime);

    }

}
