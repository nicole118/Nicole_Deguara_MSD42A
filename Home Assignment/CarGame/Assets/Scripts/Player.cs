using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float carSpeed = 10f;

    float padding = 0.5f;
    float Min_X, Max_X;

    // Start is called before the first frame update
    void Start()
    {
        SetMove();
        MoveCar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MoveCar()
    {
        var InputX = Input.GetAxis("Horizontal") * Time.deltaTime * carSpeed;
        var newXPos = transform.position.x + InputX;
        newXPos = Mathf.Clamp(newXPos, Min_X, Max_X);

        var InputY = Input.GetAxis("Vertical") * Time.deltaTime;

        transform.position = new Vector2(newXPos, InputY);

    }


    private void SetMove()
    {
        //setting the camera border 
        Camera gameCamera = Camera.main;

        var Min_X = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        var Max_X = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        var Min_Y = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        var Max_Y = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

}
