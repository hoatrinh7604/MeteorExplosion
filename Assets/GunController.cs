using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] float rotaeSpeed;
    [SerializeField] float sensitivity = .5f;
    [SerializeField] Vector3 deltaMove;

    [SerializeField] GameObject mover;
    private Vector2 turn;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;

        if (turn.y < -25) turn.y = -25;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        //transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);

        //deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * rotaeSpeed * Time.deltaTime;
    }
}
