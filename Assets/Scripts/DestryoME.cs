using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestryoME : MonoBehaviour
{
    public float lifetime = 1F;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
