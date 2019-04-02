using UnityEngine;
using System.Collections;

public class Follower : MonoBehaviour
{

    public GameObject cible;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = cible.transform.position;

    }
}
