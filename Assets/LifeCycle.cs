using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    // �ʱ�ȭ ����::
    // ������Ʈ ���� �� ���� ���� ����, 1���� ����
    void Awake()
    {
        Debug.Log("Data is ready.");
    }
    //������Ʈ Ȱ��ȭ
    void OnEnable()
    {
        Debug.Log("Welcome to Summoner's Rift.");
    }
    // ������Ʈ ���� ���� ����
    void Start()
    {
        Debug.Log("Equipments are ready.");
    }
    // ������ ����::
    // �������� ����:
    // �������� ���� �� ������Ʈ (50������ �������� �۵�)
    void FixedUpdate()
    {
        Debug.Log("Go Top.");
    }
    // ���ӷ��� ����:
    // FixedUpdate�� ����ϳ� ���� �ֱⰡ �����Ǿ� ����x (�⺻ 60������)
    void Update()
    {
        Debug.Log("Taming is now!!");
    }
    // ��� ������Ʈ ���� �� ���������� ȣ��
    void LateUpdate()
    {
        Debug.Log("Jungle chai.");
    }
    // ������Ʈ ��Ȱ��ȭ
    void OnDisable()
    {
        Debug.Log("First Blood.");
    }
    // ��ü ����::
    // ���� ������Ʈ ���� ���� ���� ��Ģ ����
    void OnDestroy()
    {
        Debug.Log("Data has removed.");
    }
}
