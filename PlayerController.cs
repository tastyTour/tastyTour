using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour//Tour
{
	private Rigidbody playerRigidbody;
	public float speed = 8f;//퍼블릭으로 속도 변수 선언
    // Start is called before the first frame update
    void Start()
    {
		//게임 오브젝트에서 리지드바디 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		float xInput = Input.GetAxis("Horizontal");//가로 변수 xInput
		float zInput = Input.GetAxis("Vertical");//세로 변수 zInput

		float xSpeed = xInput * speed;//xSpeed는 xInput(1) X speed변수
		float zSpeed = zInput * speed;//zSpeed는 zInput(1) X speed변수

		//Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
		Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
		playerRigidbody.velocity = newVelocity;//리지드바디의 속도에 Vector3 값인 newVelocity 할당
    }
	
	public void Die(){//Die메소드 호출시에
		gameObject.SetActive(false);//자신의 게임 오브젝트 비활성화

		GameManager gameManager = FindObjectOfType<GameManager>();
		gameManager.EndGame();
	}
}
