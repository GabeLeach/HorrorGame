using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }
    public GameObject shot;
    public Transform shotTransform;
float verticalVelocity = 0;
public float moveMultiplier = 5.0f;
public float mouseSensitivity = 5.0f;
// Update is called once per frame
float y = 0.0f;
public float fireRate = 0.5f;
public float nextFire = 0.0f;
void Update()
{
// rotate the player object about the Y axis
// based on the mouse moving left and right
float rotation = Input.GetAxis("Mouse X") * mouseSensitivity;
transform.Rotate(0, rotation, 0);
// rotate the camera (the player's "head") about its X axis
// based on the mouse moving up and down
float updown = Input.GetAxis("Mouse Y") * mouseSensitivity;
if(y+updown > 80 || y + updown < -85){
    updown=0;
}
Camera.main.transform.Rotate(updown * -1, 0, 0);
y += updown;

// moving the player object forwards and backwards
float forwardSpeed = Input.GetAxis("Vertical") *moveMultiplier;
// moving left to right
float lateralSpeed = Input.GetAxis("Horizontal") * moveMultiplier;
// apply gravity – or rather figure out the resultant velocity
verticalVelocity += Physics.gravity.y * Time.deltaTime;
CharacterController characterController = GetComponent<CharacterController>();
if (Input.GetButton("Jump") && characterController.isGrounded)
{
verticalVelocity = 5;
}
Vector3 speed = new Vector3(lateralSpeed, verticalVelocity, forwardSpeed);
// transform this absolute speed relative to the player's current rotation
// i.e. we don't want them to move "north", but forwards depending on where
// they are facing
speed = transform.rotation * speed;
// what is deltaTime?
// move at a different speed to make up for variable framerates
characterController.Move(speed * Time.deltaTime);
if(Input.GetButton("Fire1") && Time.time > nextFire){
    nextFire = Time.time + fireRate;
    Instantiate(shot,
    shotTransform.position,
    Camera.main.transform.rotation);
}
}
}