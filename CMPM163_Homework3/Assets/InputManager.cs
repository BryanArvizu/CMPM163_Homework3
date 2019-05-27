using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Transform subject;
    [SerializeField] private float speed = 2;

    private Vector3 targetPos = Vector3.zero;

    void Start()
    {
        if (subject != null)
            targetPos = subject.position;
    }

    // Update is called once per frame
    void Update()
    {
        float shift = Input.GetAxis("Horizontal");
        if (shift != 0)
            transform.RotateAround(targetPos, Vector3.up, speed * 10 * Time.deltaTime * shift);
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
    }
}
