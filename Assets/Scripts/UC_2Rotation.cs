using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UC_2Rotation : MonoBehaviour
{
    //2.Rotation
    //2-0.Euler Angle ==> Quternion으로 변환해 사용
    //-Gymbol lock 문제를 해결하기 위해 Unity Engine 내부적으로 Quternion 사용

    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        //RotateGameObject(new Vector3(0f, (Mathf.Cos(timer) * 0.5f + 0.5f) * 360f, 0f));
        //RotateControlForward(new Vector3(Mathf.Cos(timer), 0f, Mathf.Sin(timer)));
        //LookPosition(new Vector3(Mathf.Cos(timer), 0f, Mathf.Sin(timer)));
        LookGameObject(lookingObject);
    }
    //2-1. Euler를 사용한 Rotation 직접 회전 
    public void RotateGameObject(Vector3 rotation)
    {
        transform.rotation = Quaternion.Euler(rotation);
    }
    //2-2. 바라보는 방향을 지정해주는 LookAt 함수
    public void LookPosition(Vector3 pos)
    {
        transform.LookAt(pos);
    }

    [SerializeField]
    private Transform lookingObject;
    //2-2-1. LookGameObject 함수'
    //-회전 or 공전에 사용 <용이>
    public void LookGameObject(Transform lookobj)
    {
        transform.LookAt(lookobj);
    }

    //2-3. forward를 사용한 회전
    //-forward를 바라보고자 하는 방향으로 지정하면, 화면의 정면을 향하게 해줌
    public void RotateControlForward(Vector3 dir)
    {
        transform.forward = dir;
    }
}
