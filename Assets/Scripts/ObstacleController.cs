using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{   
    [SerializeField ]private float velocity = 5f;
    [SerializeField] private GameObject me;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(me, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * velocity; 
    }
}
