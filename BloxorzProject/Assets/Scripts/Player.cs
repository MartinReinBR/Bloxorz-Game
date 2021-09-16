using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int points = 0;

    [SerializeField] private  float TurnSpeed = 300;
    private bool isRolling;

    [SerializeField] private Renderer rend;
    [SerializeField] private UI ui;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isRolling)
        {
            isRolling = true;
            StartCoroutine(RollCube(Vector3.forward, rend.bounds.max.z));
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isRolling)
        {
            isRolling = true;
            StartCoroutine(RollCube(Vector3.back, rend.bounds.min.z));
        }
        if (Input.GetKeyDown(KeyCode.D) && !isRolling)
        {
            isRolling = true;
            StartCoroutine(RollCube(Vector3.right, rend.bounds.max.x));
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isRolling)
        {
            isRolling = true;
            StartCoroutine(RollCube(Vector3.left, rend.bounds.min.x));
        }
    }

    IEnumerator RollCube(Vector3 direction, float dir)
    {
        float remainingAngle = 90;
        Vector3 rotationCenter = rend.bounds.center;

        if(direction.x != 0)
        {
            rotationCenter = new Vector3(dir, rend.bounds.min.y, 0);
        }

        else if(direction.z != 0)
        {
            rotationCenter = new Vector3(0, rend.bounds.min.y, dir);
        }
        
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle > 0)
        {
            float rotationAngle = Mathf.Min(Time.deltaTime * TurnSpeed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        isRolling = false;
    }

    public void AddPoints()
    {
        points++;
        ui.SetPointsText(points);
    }

}
