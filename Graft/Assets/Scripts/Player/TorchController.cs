using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;
    [SerializeField] float offsetZ;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cameraTransform.position.x + offsetX, cameraTransform.position.y + offsetY, cameraTransform.position.z + offsetZ);


    }
}
