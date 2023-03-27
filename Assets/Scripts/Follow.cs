using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public Transform Target;
    public float LerpRate;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * LerpRate);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
