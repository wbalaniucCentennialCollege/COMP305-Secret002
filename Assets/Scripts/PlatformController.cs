using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public Sprite disabledSwitch;
    public Sprite enabledSwitch;
    public Vector2 pointL;
    public Vector2 pointR;

    private SpriteRenderer sRend;
    private bool isMoveR = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (isMoveR)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, pointR, Time.deltaTime * 3.0f);

            Debug.Log(this.transform.position);

            if(this.transform.position.x >= pointR.x)
            {
                Debug.Log("Reached R");
                isMoveR = false;
            }
        } else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, pointL, Time.deltaTime * 3.0f);

            if (this.transform.position.x <= pointL.x)
            {
                isMoveR = true;
            }
        }
	}
}
