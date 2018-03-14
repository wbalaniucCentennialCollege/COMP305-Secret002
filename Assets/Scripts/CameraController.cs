using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float offset = 5.0f;
    public Transform playerPos;

	void Start()
    {

    }

    void Update()
    {
        if(playerPos.position.x > this.transform.position.x + offset)
        {
            this.transform.position = new Vector3(playerPos.position.x - this.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + offset, this.transform.position.y, this.transform.position.z));
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x - offset, this.transform.position.y, this.transform.position.z));
    }
}
