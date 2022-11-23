using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletprefab;//������ ź���� ���� ������
    public float spawnRateMin = 0.5f;//�ּ� ���� �ֱ�
    public float spawnRateMax = 3f;//�ִ� ���� �ֱ�

    private Transform target;//�߻��� ���
    private float spawnRate;//���� �ֱ�
    private float timeAfterSpawn;//�ֱ� ���� �������� ���� �ð�

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;//�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);//ź�� ���� ������ spawnRateMin�� spawnRateMax���̿��� ���� ����
        target = FindObjectOfType<PlayerController>().transform;//PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;//timeAfterSpawn ����

        if(timeAfterSpawn >= spawnRate)//�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        {
            timeAfterSpawn = 0f;//������ �ð��� ����
            //�������� ��������
            //transform.position(��ġ)�� transform.rotate (ȸ��)�� �����Ͽ� ����
            GameObject bullet = Instantiate(bulletprefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);//������ �Ҹ� ���� ������Ʈ�� ���� ������ Ÿ���� ���ϵ��� ȸ��
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);//������ ���� ������ spawnratemin, spawnratemax ���̿��� ���� ����
        }
    }
}
