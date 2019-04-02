using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public GameObject centerOrigin;
    public Vector3 speed = new Vector3(15,30,45);

    void Start() {
        if (centerOrigin == null)
        {
            centerOrigin = this.gameObject;
        }
    }

	// Update is called once per frame
	void Update () {
        transform.RotateAround(centerOrigin.transform.position, speed, 40 * Time.deltaTime);
	}
}
