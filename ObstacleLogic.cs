/*****************************************************************//**
 * \file   ObstacleLogic.cs
 * \brief  Simply translates objects and destroys them off camera.
 * 
 * \author Mike Doeren
 * \date   July 2023
 *********************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLogic : MonoBehaviour
{
    // Variables
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object through the z-axis over DT
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Called when the object is invisible to the camera
    private void OnBecameInvisible()
    {
        // Destroy the object when it's off screen
        Destroy(gameObject);
    }
}
