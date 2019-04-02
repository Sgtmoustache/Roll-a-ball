using UnityEngine;
using System.Collections;

public class MagicPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        GameObject Folder = GameObject.FindGameObjectWithTag("Collectibles");
        this.transform.SetParent(Folder.transform);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
