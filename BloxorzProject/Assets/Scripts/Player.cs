using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float points = 0;

    public float TurnSpeed = 300;
    bool isRolling;

    public Renderer rend;

    public void AddPoints()
    {
        points++;
        if (points >= 10)
        {
            Debug.Log("All Coins, GO next life bussy");
        }
    }

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
            Debug.Log("X");
            rotationCenter = new Vector3(dir, rend.bounds.min.y, 0);
        }
        else if(direction.z != 0)
        {
            Debug.Log("Y");
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

}
