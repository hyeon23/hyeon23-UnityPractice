using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UC_7Instantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;
    [SerializeField]
    private GameObject[] prefabArray;
    [SerializeField]
    private int objectSpawnCount = 30;
    [SerializeField]
    private Transform[] spawnPointArray;
    private void Awake()
    {
        Instantiate(boxPrefab);
        Instantiate(boxPrefab);

        Instantiate(boxPrefab, new Vector3(3, 3, 0), Quaternion.identity);//Prefab, 생성위치, 생성방향을 설정하는 형태
        //Quterniono.identity = 회전 값 (0, 0, 0)

        //Euler: 우리가 흔히 아는 0 ~ 360의 각도 표현방식
        //연산속도가 느리고, 짐벌락 현상이 발생

        //Quternion: 4원수, 3개의 벡터요소와 1개의 스칼라요소로 구성(4개의 -1 ~ 1 값)
        //성능이 좋지만 각도표현이 어려움 => 오일러를 쿼터니언으로 변경하는 함수 Quaternion.Euler
        Quaternion EuToQua = Quaternion.Euler(0,0,0);

        //transform.rotation: 쿼터니언을 이용한 회전정보
        //transform.localScale: 오일러를 이용한 Scale값

        //Instantiate의 반환 값이 GameObject이기 때문에 GameObject형 변수에 저장 및 사용법
        GameObject clone = Instantiate(boxPrefab, Vector3.zero, EuToQua);
        //방금 생성된 게임 오브젝트의 이름 변경
        clone.name = "Box01";
        //방금 생성된 게임 오브젝트의 색상 변경
        clone.GetComponent<SpriteRenderer>().color = Color.black;
        //방금 생성된 게임 오브젝트의 위치 변경
        clone.transform.position = new Vector3(2, 1, 0);
        //방금 생성된 케임 오브젝트의 크기 변경
        clone.transform.localScale = new Vector3(3, 2, 1 );

        //Instantiate 활용 예제
        //1. 10개의 오브젝트가 잔상을 남기며 회전 이동하는 듯한 이미지
        for(int i = 0; i < 10; i++)
        {
            Vector3 position = new Vector3(-4.5f + i, 0, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, i * 10);
            Instantiate(boxPrefab, position, rotation);
        }

        //2. 10 X 10 모양의 격자 형태의 맵 생성
        for (int y = 0; y < 10; y++)
        {
            for(int x = 0; x < 10; x++)
            {   
                if(x == y)//\
                    continue;
                if (x == y || x + y == 9)//X
                    continue;
                if (x + y == 4 || x - y == 5 || y - x == 5 || x + y == 14)//마름모
                    continue;
                Vector3 position = new Vector3(-4.5f + x, 4.5f - y, 0);
                Instantiate(boxPrefab, position, Quaternion.identity);
            }
        }

        //3. 랜덤 프리팹을 통한 오브젝트 생성
        for(int i = 0; i < 10; i++)
        {
            int index = Random.Range(0, prefabArray.Length);
            Vector3 position = new Vector3(-4.5f + i, 0, 0);
            Instantiate(prefabArray[index], position, Quaternion.identity);
        }

        //4. 랜덤 함수를 통해 임의의 위치에 Prefab 생성
        for(int i = 0; i < objectSpawnCount; i++)
        {
            int index = Random.Range(0, prefabArray.Length);
            float x = Random.Range(-7.5f, 7.5f);
            float y = Random.Range(-4.5f, 4.5f);
            Vector3 position = new Vector3(x, y, 0);
            Instantiate(prefabArray[index], position, Quaternion.identity);
        }

        //5. 랜덤 특정 위치에서 랜덤 프리팹 생성하기
        for(int i = 0; i < objectSpawnCount; i++)
        {
            int prefabIndex = Random.Range(0, prefabArray.Length);
            int spawnIndex = Random.Range(0, spawnPointArray.Length);

            Vector3 position = spawnPointArray[spawnIndex].position;
            GameObject C = Instantiate(prefabArray[prefabIndex], position, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
