using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Vector3 offset;
    public GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {
        offset = personaje.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = personaje.transform.position - offset;
    }
}
