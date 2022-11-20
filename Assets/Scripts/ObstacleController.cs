using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(this.speed * Time.deltaTime * Vector3.forward);
    }

    private void OnBecameInvisible()
    {
        //when obstacle is not seen by camera
        Destroy(gameObject);
    }
}
