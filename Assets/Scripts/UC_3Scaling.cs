using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UC_3Scaling : MonoBehaviour
{
    //3.Scale
    //3-0.Local Scale 사용 이유
    //-LocalScale => Local 좌표계상에서 크기 변환
    //-lossyScale => World 좌표계상에서 크기 변환
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        Scaling(new Vector3(Mathf.Cos(timer), Mathf.Cos(timer), Mathf.Cos(timer)));
    }

    public void Scaling(Vector3 newScale)
    {
        transform.localScale = newScale;
    }
}
