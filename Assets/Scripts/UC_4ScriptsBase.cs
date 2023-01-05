using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UC_4ScriptsBase : MonoBehaviour
{
    //0. MonoBehaviour를 상속받으면 GameObject의 Component로 부착될 수 있음
    //-상속받지 못하면 Component로 부착되지 못함

    //생성
    //Awake
    //OnEnable
    //Start
    private void Awake()
    {
        //오브젝트가 생성되어 Component에 Script가 부착될 시 호출됨
        Debug.Log("Awake");
    }
    private void OnEnable()
    {
        //활성상태가 되면 호출
        Debug.Log("OnEnable");
    }
    private void Start()
    {
        //Awake와 다르게 게임 오브젝트가 활성화된 경우 Update 호출 직전 단 한번 호출
        Debug.Log("Start");
    }

    //업데이트
    //Fixed Update
    //Update
    //LateUpdate
    private void FixedUpdate()
    {
        //프레임과 상관없는 동작을 원하는 경우
        Debug.Log("FixedUpdate");
    }
    int count = 0;
    private void Update()
    {
        count++;
        if(count > 100)
        {
            Destroy(gameObject);//gameObject는 스크립트가 부착된 오브젝트를 말함
        }
        else
        {
            Debug.Log("Update");
        }
    }
    private void LateUpdate()
    {
        //결과가 반영된 뒤 처리하고 싶은 작업
        Debug.Log("LateUpdate");
    }

    //소멸
    //OnDisable
    //OnDestroy
    private void OnDisable()
    {
        //비 활성상태가 되면 호출
        Debug.Log("OnDisable");
    }
    private void OnDestroy()
    {
        //Monobehavior가 제거되며오브젝트가 없어지면 호출
        Debug.Log("OnDestroy");
    }
}
