using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D inactiveCursorTexture;
    public Texture2D activeCursorTexture;
    public Player player;
    public Camera cam;
    // the max distance the cursor can be from the player and still interact with things
    public float interactableDistance;
    bool isCursorActive = false;
    static Vector2 centerOfCursor = new Vector2(16, 16);


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }


    private void OnDrawGizmos()
    {
       // Gizmos.DrawSphere(player.transform.position, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Debug.DrawLine(cursorWorldPos, player.transform.position, Color.yellow, .5f, false);


        if ( Vector2.Distance( new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(cursorWorldPos.x,cursorWorldPos.y)) > interactableDistance)
        {
            Cursor.SetCursor(inactiveCursorTexture, centerOfCursor, CursorMode.Auto);
            isCursorActive = false;
        }
        else
        {
            Cursor.SetCursor(activeCursorTexture, centerOfCursor, CursorMode.Auto);
            isCursorActive = true;
        }
    }
}
