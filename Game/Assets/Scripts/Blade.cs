using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Blade : MonoBehaviour {
    //End Game Ui
    public GameObject GG;
    public GameObject gameOver;
    public GameObject pause;

    public Text endKilled;
    public Text endMistakes;
    public Text accuracy;

    //Game
    public Text fruitSpawned;
    public Text TargetFruitSpawned;
    public Text Killed;

    public Text Target;
    public Text TargetKilled;
    public Text Mistakes;

    public int fruitKilled;
    public int targetFruitKilled;
    public int mistakeCount;

    public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;
    bool isCutting = false;

    Vector2 previousPosition;

	GameObject currentBladeTrail;

	Rigidbody2D rb;
	Camera cam;
	CircleCollider2D circleCollider;

    public ParticleSystem SmallExplosion;
    public ParticleSystem BigExplosion;

    public GameObject bladeObject;

    void Start ()
	{
        Time.timeScale = 1f;

        gameOver.SetActive(false);
        pause.SetActive(false);
        GG.SetActive(false);

        cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Fruit" || col.tag == "Apple" || col.tag == "Kiwi" || col.tag == "Strawberry")
        {
            fruitKilled += 1;
            Killed.text = fruitKilled.ToString();

            endKilled.text = fruitKilled.ToString();

            if (col.tag == Target.text)
            {
                targetFruitKilled += 1;
                TargetKilled.text = targetFruitKilled.ToString();
                ParticleSystem particle = Instantiate(SmallExplosion, col.transform.position, col.transform.rotation);
                particle.Play();
            }
            else {
                mistakeCount += 1;
                Mistakes.text = mistakeCount.ToString();
                endMistakes.text = mistakeCount.ToString();
                accuracy.text = ((Int32.Parse(TargetFruitSpawned.text) / targetFruitKilled) - mistakeCount).ToString();
            }
        }

        if (col.tag == "Bomb")
        {
            ParticleSystem particle = Instantiate(BigExplosion, col.transform.position, col.transform.rotation);
            mistakeCount += 1;
            Mistakes.text = mistakeCount.ToString();
            particle.Play();
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            pause.SetActive(true);
        }

        if (mistakeCount > 5)
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }

        if (targetFruitKilled > 150)
        {
            Time.timeScale = 0f;
            GG.SetActive(true);
        }

        if (targetFruitKilled > 0)
        {
            Target.text = "Apple";
        }

        if (targetFruitKilled > 50)
        {
            Target.text = "Kiwi";
        }

        if (targetFruitKilled > 100)
        {
            Target.text = "Strawberry";
        }

        if (Input.GetMouseButtonDown(0))
		{
			StartCutting();
		} else if (Input.GetMouseButtonUp(0))
		{
			StopCutting();
		}

		if (isCutting)
		{
			UpdateCut();
		}

	}

	void UpdateCut ()
	{
		Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition; 

		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
		if (velocity > minCuttingVelocity)
		{
			circleCollider.enabled = true;
		} else
		{
			circleCollider.enabled = false;
		}

		previousPosition = newPosition;
	}

	void StartCutting ()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		circleCollider.enabled = false;
	}

	void StopCutting ()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f);
		circleCollider.enabled = false;
	}

}
