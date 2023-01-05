using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UC_5Variable : MonoBehaviour
{
    //1.일반 자료형
    //int: -214783647 ~ 214783648 범위의 정수
    //float: 소수점 다섯째까지 정확도의 실수 표현, f 붙이는 것 필수
    //string: 문자집합
    //bool: true or false

    //2.특수 자료형
    //-배열(int[], float[], string[]. bool[])
    //-일반 C# 클래스 or MonoBehaviour를 상속받은 클래스(Animator animator)

    //3.접근제한자
    //3-1.public
    //-public 변수는 Editor에서 직접 값 수정 가능
    //-public 클래스는 변수 및 함수 참조 직접 가능
    //3-1-1.[SerializedField]: public처럼 Editor에서 수정하면서 사용하고 싶은데, Protected나 Private로 외부 클레스에서 접근을 막고싶은 경우 사용
    //3-1-2.[HideInInspector]: public 상태에서 Editor에서 수정하는 것이 필요 없을 때 사용
    //3-2.Private
    //3-3.Protected
}
