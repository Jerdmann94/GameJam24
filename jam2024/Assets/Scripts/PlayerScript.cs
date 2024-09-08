using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Camera;

public class PlayerScript : MonoBehaviour
{
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = main;
    }

    // Update is called once per frame
    void Update()
    {
        if (_camera) _camera.transform.LookAt(transform.position + new Vector3(0, 1, 0));
    }
}
