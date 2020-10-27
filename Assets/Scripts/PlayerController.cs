using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public GameObject item;
    public float spawnDistance = 3.0f;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Check for floor contact
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Player-controlled movement update
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x) + (transform.forward * z);
        controller.Move(move * speed * Time.deltaTime);

        // Check for jumping
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity update
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Check for item spawn
        if(Input.GetKeyDown("f"))
        {
            StartCoroutine(SpawnItem());
        }
    }

    // Spawn an item
    IEnumerator SpawnItem()
    {
        Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * spawnDistance;

        Instantiate(item, spawnPosition, Quaternion.identity);

        yield return new WaitForSeconds(0.1f);
    }
}
