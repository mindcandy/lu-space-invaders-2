using UnityEngine;
using System.Collections;

public class SpecialInvader : MonoBehaviour {

	public float minDelayTime = 5.0f;
	public float maxDelayTime = 10.0f;
	public float speed = 5.0f;

	public float startX = -7.5f;
	public float endX = 7.5f;

	bool _moving;
	float _timer;
//	AudioSource _source;

	// Use this for initialization
	void Start () {
//		_source = GetComponent<AudioSource>();
		WaitToAppear();
	}
	
	// Update is called once per frame
	void Update () {
		if (_moving) {
			transform.position += new Vector3(speed * Time.deltaTime, 0.0f);
			if (transform.position.x > endX) {
				WaitToAppear();
			}
		} else {
			_timer -= Time.deltaTime;
			if (_timer < 0.0f) {
				_moving = true;
//				_source.Play();
			}
		}
	}

	void WaitToAppear() {
//		_source.Stop();
		_moving = false;
		transform.position = new Vector2(startX, transform.position.y);
		_timer = Random.Range(minDelayTime, maxDelayTime);
	}
}
