using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float       speed = 5.0f;           //이동속도
    [SerializeField]
    private float       jumpForce = 8.0f;       //점프 크기
    private Rigidbody2D rigid2D;
    [HideInInspector]
    public bool         isLongJump = false;     //낮점, 높점 체크

    [SerializeField]
    private LayerMask           groundLayer;        //바닥 충돌 체크를 위한 레이어
    private CapsuleCollider2D   capsuleCollider2D;  //오브젝트의 충돌 범위 컴포넌트
    private bool                isGrounded;         //바닥 체크
    private Vector3             footPosition;       //발 위치

    [SerializeField]
    private int         maxJumpCount = 2;//최대 점프 갯수
    private int         currentJumpCount = 0;//현재 가능한 점프 횟수

    private void Awake()
    {
        rigid2D             = GetComponent<Rigidbody2D>();
        capsuleCollider2D   = GetComponent<CapsuleCollider2D>();
    }


    private void FixedUpdate()//낮점 높점 구현
    {
        Bounds bounds       = capsuleCollider2D.bounds;//Collider의 범위를 표현해주는 bound
        capsuleCollider2D   = GetComponent<CapsuleCollider2D>();
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);
        //OverlapCircle(Vector2 position, float radius, LayerMask layer): position 위치의 반지름 만큼의 원 충돌범위를 생성해 원에 충돌하는 오브젝트의 collider2D 컴포넌트를 저장

        if (isGrounded == true && rigid2D.velocity.y <= 0)
        {
            currentJumpCount = maxJumpCount;
        }
        //gravityScale을 통해 구현
        if(isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }
        else
        {
            rigid2D.gravityScale = 2.5f;
        }
    }

    private void OnDrawGizmos()//게임이는 보이지 않고, Scene 뷰에서만 보이는 Ray같은 오브젝트를 그릴 수 있는 함수
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPosition, 0.1f);
    }

    public void Move(float x)
    {
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        //if(isGrounded == true)
        if(currentJumpCount > 0)
        {
            rigid2D.velocity = Vector2.up * jumpForce;
            currentJumpCount--;
        }
    }
}
