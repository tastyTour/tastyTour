using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour//Tour
{
	public float speed = 8f;//퍼블릭으로 탄알의 속도 변수 선언(퍼블릭으로 선언시 유니티에서 값 변경 가능)
	private Rigidbody bulletRigidbody;//프리베이트로 bullet의 리지드바디 값 할당
    // Start is called before the first frame update
    void Start()
    {
		//게임 오브젝트에서 리지드바디 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();

		//리지드바디의 속도(가하는 힘) = 앞쪽방향 * 이동속력
		bulletRigidbody.velocity = transform.forward * speed;

		//3초뒤에 자신의 게임 오브젝트 파괴
		Destroy(gameObject, 3f);
    }
	//트리거 충돌시에 자동으로 실행이 되는 메서드
	void OnTriggerEnter(Collider other)
	{
		//충돌한 상대방 게임 오브젝트 이름이 Player라면
		if(other.tag == "Player")
		{
			//상대방 게임 오브젝트에서 PlayerController 컴포넌트를 가져온다
			PlayerController playerController = other.GetComponent<PlayerController>();
			//PlayerController 컴포넌트를 가져오는 데 성공했으면
			if(playerController != null)
			{
				//playerController.Die 메소드 실행
				playerController.Die();
			}
		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
