using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public List<Transform> backgrounds = new List<Transform>();
    public float movementSpeed;

    private Transform cam;
    private float[] skalaParalax;
    private Vector3 prevPosCam;


    private void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        prevPosCam = cam.position;

        skalaParalax = new float[backgrounds.Count];

        for (int i = 0; i < backgrounds.Count; i++)
        {
            skalaParalax[i] = backgrounds[i].position.z * -1;
        }
    }

    void Update()
    {
        for (int i = 0; i < backgrounds.Count; i++)
        {
            float parallax = (prevPosCam.x - cam.position.x) * skalaParalax[i];
            float BGTargetPosX = backgrounds[i].position.x + parallax;
            Vector3 BGNewPos = new Vector3(BGTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, BGNewPos, movementSpeed * Time.deltaTime);
        }
        prevPosCam = cam.position;
    }
}
