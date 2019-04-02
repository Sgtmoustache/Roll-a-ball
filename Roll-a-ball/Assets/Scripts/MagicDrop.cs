using UnityEngine;
using System.Collections;

public class MagicDrop : MonoBehaviour {

    public GameObject drop;
    public float speedOfSpawn;

    // Use this for initialization
    void Start() {

        if(drop != null)
            InvokeRepeating("Drop", speedOfSpawn, speedOfSpawn);
    }

    // Update is called once per frame
    void Update() {

    }

    void Drop()
    {
        var newdrop = GameObject.Instantiate(drop);
        newdrop.transform.position = this.transform.position + new Vector3(0,1,0);
    }
}
