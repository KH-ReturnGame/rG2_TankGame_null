using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    // 초기화 영역::
    // 오브젝트 생성 시 가장 먼저 실행, 1번만 실행
    void Awake()
    {
        Debug.Log("Data is ready.");
    }
    //오브젝트 활성화
    void OnEnable()
    {
        Debug.Log("Welcome to Summoner's Rift.");
    }
    // 업데이트 직전 최초 실행
    void Start()
    {
        Debug.Log("Equipments are ready.");
    }
    // 프레임 영역::
    // 물리연산 영역:
    // 물리연산 시작 전 업데이트 (50프레임 고정으로 작동)
    void FixedUpdate()
    {
        Debug.Log("Go Top.");
    }
    // 게임로직 영역:
    // FixedUpdate와 비슷하나 실행 주기가 고정되어 있지x (기본 60프레임)
    void Update()
    {
        Debug.Log("Taming is now!!");
    }
    // 모든 업데이트 종료 후 마지막으로 호출
    void LateUpdate()
    {
        Debug.Log("Jungle chai.");
    }
    // 오브젝트 비활성화
    void OnDisable()
    {
        Debug.Log("First Blood.");
    }
    // 해체 영역::
    // 게임 오브젝트 삭제 직전 삭제 규칙 정의
    void OnDestroy()
    {
        Debug.Log("Data has removed.");
    }
}
