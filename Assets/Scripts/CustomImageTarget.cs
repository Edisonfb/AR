using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomImageTarget : DefaultTrackableEventHandler
{
	protected override void OnTrackingFound()
	{
		base.OnTrackingFound();
		LevelManager.Instance.SpawnBall();
	}

	protected override void OnTrackingLost()
	{
		base.OnTrackingLost();
		LevelManager.Instance.ball.gameObject.SetActive(false);
	}
}
