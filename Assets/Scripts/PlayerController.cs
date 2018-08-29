using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public List<Transform> positions = new List<Transform>();

    private void OnEnable()
    {
        Input.OnTopLeftPressed += Input_OnTopLeftPressed;
        Input.OnTopRightPressed += Input_OnTopRightPressed;
        Input.OnBottomLeftPressed += Input_OnBottomLeftPressed;
        Input.OnBottomRightPressed += Input_OnBottomRightPressed;
    }

    private void OnDisable()
    {
        Input.OnTopLeftPressed -= Input_OnTopLeftPressed;
        Input.OnTopRightPressed -= Input_OnTopRightPressed;
        Input.OnBottomLeftPressed -= Input_OnBottomLeftPressed;
        Input.OnBottomRightPressed -= Input_OnBottomRightPressed;
    }

    // Use this for initialization
    void Start () {
        transform.position = positions[0].position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Input_OnTopLeftPressed()
    {
        transform.position = positions[0].position;
    }

    void Input_OnTopRightPressed()
    {
        transform.position = positions[1].position;
    }

    void Input_OnBottomLeftPressed()
    {
        transform.position = positions[2].position;
    }

    void Input_OnBottomRightPressed()
    {
        transform.position = positions[3].position;
    }
}
