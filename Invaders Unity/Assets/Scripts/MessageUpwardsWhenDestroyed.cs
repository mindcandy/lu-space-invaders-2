using UnityEngine;
using System.Collections;

public class MessageUpwardsWhenDestroyed : MonoBehaviour {

	public string message;

	void OnDestroyed () {
		SendMessageUpwards(message);
	}
}
