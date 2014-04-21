using UnityEngine;
using System.Collections;

public class ScoreIncreasesOnDestroyed : MonoBehaviour {

	public int score;

	void InvaderDestroyed() {
		SendMessageUpwards("AddScore", score);
	}
}

