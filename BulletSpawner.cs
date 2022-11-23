using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour//Tour
{
    public GameObject bulletprefab;//생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;//최소 생성 주기
    public float spawnRateMax = 3f;//최대 생성 주기

    private Transform target;//발사할 대상
    private float spawnRate;//생성 주기
    private float timeAfterSpawn;//최근 생성 시점에서 지난 시간

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;//최근 생성 이후의 누적 시간을 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);//탄알 생성 간격을 spawnRateMin과 spawnRateMax사이에서 랜덤 지정
        target = FindObjectOfType<PlayerController>().transform;//PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;//timeAfterSpawn 갱신

        if(timeAfterSpawn >= spawnRate)//최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        {
            timeAfterSpawn = 0f;//누적된 시간을 리셋
            //프리팹의 복제본을
            //transform.position(위치)와 transform.rotate (회전)을 복제하여 생성
            GameObject bullet = Instantiate(bulletprefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);//생성된 불릿 게임 오브젝트의 정면 방향이 타겟을 향하도록 회전
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);//다음번 생성 간격을 spawnratemin, spawnratemax 사이에서 랜덤 지정
        }
    }
}
