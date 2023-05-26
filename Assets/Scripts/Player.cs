using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isJump = false;
    bool isAtTop = false;
    public float jumpHeight = 10f;
    public float jumpSpeed = 4f;
    Vector2 startPosition;
    Animator animator;

    void Start()
    {
        startPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.position.y <= startPosition.y + 0.1f && !isJump)
        {
            StartCoroutine(JumpCoroutine());
        }
    }

    IEnumerator JumpCoroutine()
    {
        isJump = true;
        isAtTop = false;
        animator.SetBool("jump", true);
        yield return new WaitForSeconds(0.15f);
        while (isJump)
        {
           
            if (!isAtTop && transform.position.y < jumpHeight - 0.1f)
            {
                Vector2 targetPosition = new Vector2(transform.position.x, jumpHeight);
                transform.position = Vector2.Lerp(transform.position, targetPosition, jumpSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("jump", false);
                animator.SetBool("run", true);
                isAtTop = true;

                if (transform.position.y > startPosition.y + 0.1f)
                {
                    Vector2 targetPosition = startPosition;
                    transform.position = Vector2.Lerp(transform.position, targetPosition, jumpSpeed * Time.deltaTime);
                }
                else
                {
                    isJump = false;
                }
            }

            yield return null;
        }
    }
}
