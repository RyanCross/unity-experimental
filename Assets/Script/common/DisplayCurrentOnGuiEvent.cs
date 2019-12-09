using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCurrentOnGuiEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        Debug.Log("Current detected event: " + Event.current);
    }
}
