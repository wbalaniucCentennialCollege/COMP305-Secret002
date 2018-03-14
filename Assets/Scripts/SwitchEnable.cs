using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEnable : MonoBehaviour {

    public GameObject platform;
    public Sprite enabledSwitch;

	void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKeyUp(KeyCode.E))
        {
            platform.GetComponent<PlatformController>().enabled = true;
            this.GetComponent<SpriteRenderer>().sprite = enabledSwitch;
            this.enabled = false;
        }
    }
}
