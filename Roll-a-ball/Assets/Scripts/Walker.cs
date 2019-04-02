//Source : http://answers.unity3d.com/questions/14279/make-an-object-move-from-point-a-to-point-b-then-b.html

using UnityEngine;
using System.Collections;

public class Walker : MonoBehaviour
{
    public GameObject zero;
    public GameObject max;
    private Vector3 previous;

    IEnumerator Start()
    {
        previous = this.transform.position;

        while (true)
        {
            var pointA = previous;
            var pointB = new Vector3(Random.Range(zero.transform.position.x, max.transform.position.x),
                                     Random.Range(zero.transform.position.y, max.transform.position.y),
                                     Random.Range(zero.transform.position.z, max.transform.position.z));
            previous = pointB;
            this.transform.LookAt(pointB,new Vector3(0, 1, 0));
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}