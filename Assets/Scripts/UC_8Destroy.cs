using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UC_8Destroy : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;
    private SpriteRenderer spriteRenderer;
    private Vector2 limitMin = new Vector2(-7.5f, -4.5f);
    private Vector2 limitMax = new Vector2(7.5f, 4.5f);
    private float time;
    //Destroy함수는 게임 오브젝트 뿐만 아니라 컴포넌트까지 삭제 가능하다.
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //특정 게임 오브젝트에 부착된 컴포넌트 삭제
        Destroy(playerObject.GetComponent<PlayerController>());
        //게임 오브젝트 삭제
        Destroy(playerObject);
        //특정 시간 후 오브젝트 삭제
        //Destroy(playerObject, time);

        //오브젝트가 특정 위치를 벗어낫을 때, 삭제
        if (transform.position.x < limitMin.x || transform.position.x > limitMax.x || transform.position.y < limitMin.y || transform.position.y > limitMax.y)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        StartCoroutine("HitAnimation");
    }
    private IEnumerator HitAnimation()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = Color.white;
    }
}
