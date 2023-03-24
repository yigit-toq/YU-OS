using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour {

	public PC pc;
	public Karakter karakter;

	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;

	public Transform Hedef;

	private void Start()
    {
		pc = FindObjectOfType<PC>();

		xMin = -4f;
		xMax = 693f;
		yMin = -6f;
		yMax = 30;
    }

	private void Update ()
    {
        if (karakter.Level == 7)
        {
			yMin = -160f;
			xMax = 749f;
		}
    }

	private void LateUpdate () 
	{
        if (pc.GameScreen.activeSelf)
        {
			transform.position = new Vector2(Mathf.Clamp(Hedef.position.x, xMin, xMax), Mathf.Clamp(Hedef.position.y, yMin, yMax));
		}
	}
}
