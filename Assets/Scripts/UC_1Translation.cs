using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UC_1Translation : MonoBehaviour
{
    //1. 이동(Translation)
    float timer = 0f;
    void Update()
    {
        timer += Time.deltaTime;
        //movePosition1(new Vector3(0f, Mathf.Cos(timer), 0f));
        moveTranslate1(new Vector3(0f, Mathf.Cos(timer), 0f));
    }
    //1-1. transform.position
    //-해당 위치로 직접이동
    private void movePosition1(Vector3 newPos)
    {
        transform.position = newPos;
    }
    //1-2. transform.Translate()
    //-해당 Vector만큼의 힘을 주는 것
    //-60프레임동안 1이 될때까지 계속적으로 힘을 준다.
    private void moveTranslate1(Vector3 moveVec)
    {
        transform.Translate(moveVec);
    }
}
