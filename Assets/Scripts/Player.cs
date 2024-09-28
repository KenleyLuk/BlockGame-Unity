using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public float maxVelocity;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // bool isMoving = false;
        // if (Input.GetMouseButton(0))
        // {
        //     Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //     // Calculate the distance between the current player position and the touch position
        //     float distanceToTouch = touchPos.x - transform.position.x;
        //     if (Mathf.Abs(distanceToTouch) > 0.1f && !isMoving)
        //     {
        //         isMoving = true;
        //     }

        //     if (isMoving)
        //     {
        //         // Calculate the target velocity based on the distance to the touch position
        //         float targetVelocity = Mathf.Sign(distanceToTouch) * moveSpeed;

        //         // Clamp the target velocity to ensure it does not exceed the maximum allowed velocity
        //         float newVelocity = Mathf.Clamp(targetVelocity, -maxVelocity, maxVelocity);

        //         // Update the Rigidbody's velocity in the x-axis while preserving the y-axis velocity
        //         rb.velocity = new Vector2(newVelocity, rb.velocity.y);
        //     }
        // }
        // else
        // {
        //     rb.velocity = Vector2.zero;
        // }

        bool isMoving = false;
        Vector3 targetPosition = transform.position; // 初始化目标位置为当前位置

        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z; // 保持 z 轴位置与玩家一致

            // 计算当前位置到目标位置的距离
            float distanceToTarget = targetPosition.x - transform.position.x;

            if (Mathf.Abs(distanceToTarget) > 0.1f)
            {
                isMoving = true;
            }
        }

        if (isMoving)
        {
            // 移动角色向目标位置
            float distanceToTarget = targetPosition.x - transform.position.x;
            float targetVelocity = Mathf.Sign(distanceToTarget) * moveSpeed;
            float newVelocity = Mathf.Clamp(targetVelocity, -maxVelocity, maxVelocity);

            rb.velocity = new Vector2(newVelocity, rb.velocity.y);

            // 如果非常接近目标位置，停止移动
            if (Mathf.Abs(distanceToTarget) < 0.1f)
            {
                isMoving = false;
                rb.velocity = Vector2.zero;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
