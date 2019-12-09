using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplestCamera : MonoBehaviour
{
    public Player player;
    public Camera camera;
    public Vector3 lastKnownRelativeMousePosition;
    public Vector3 lastKnownCursorScreenPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            updateCameraPosition();
        }
    }

    void updateCameraPosition()
    {
        Vector3 cursorWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);
        //get distance and direction of cursor (vector) relative to the player.
        Vector3 relativeMousePos = player.transform.InverseTransformPoint(cursorWorldPos);
        Debug.Log("Cursor vector relative to player" + relativeMousePos);
        Debug.DrawLine(player.transform.position, relativeMousePos, Color.yellow, .5f, false);

   
        if(Input.mousePosition != lastKnownCursorScreenPos)
        {
            lastKnownCursorScreenPos = Input.mousePosition;
            camera.transform.position = relativeMousePos;
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, .5f);
    }

    private void FixedUpdate()
    {

    }

    void calculateLocalCursorVector()
    {
        // here "local" means the position of the cursor relative to the player's origin.
    }

    Vector3 getLocalMousePosition()
    {
        Vector3 cursorWorldPos = camera.ScreenToWorldPoint(Input.mousePosition);
        //get distance and direction of cursor (vector) relative to the player.
        return player.transform.InverseTransformVector(cursorWorldPos);
    }
}
