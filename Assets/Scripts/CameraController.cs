using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables
    public PlayerController playerController;
    public bool Flipface;
    public Transform target1;
    public Vector3 offset;
    public float damping = 0.5f;
    private Vector3 velocity = Vector3.zero;
    #endregion

    #region Camera Algorithm
    void LateUpdate()
    {
        if (playerController == null) return;

        if (playerController.FaceControl == false)
        {
            _ = target1.position + offset;
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, new Vector3((target1.position.x - 6), (target1.position.y + 3), gameObject.transform.position.z), ref velocity, damping);

        }
        if (playerController.FaceControl == true)
        {
            _ = target1.position + offset;
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, new Vector3((target1.position.x + 6), (target1.position.y + 3), gameObject.transform.position.z), ref velocity, damping);
        }
    }
    #endregion



}
