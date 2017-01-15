using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class StarManager : MonoBehaviour {

    public GameObject starPrefab; // The star to spawn
    public float maxDistance;
    public float force = 1f;
    public List<Transform> targets;
    public int winCondition; // in order to win
    public VRInteractiveItem intItem;
    public VRInput inputItem;
    public findcentroid starCenter;
    public Vector3 veryCenter;
    public GameObject[] constellation;
    public GameObject mainCamera;
    public VRCameraFade camFade;

    public Text Title;
    public Text Body;
    // Use this for initialization
    void Start () { 
        for (int i = 0; i < 200; i++)
        {
            Instantiate(starPrefab, randomPos(-1, 1), Quaternion.identity);
        }
        if (mainCamera.GetComponent<VRCameraFade>() != null)
        {
            camFade = mainCamera.GetComponent<VRCameraFade>();
        }
        else
        {
            print("No VR Camera Fade exists!");
        }

        Invoke("DimUI", 5);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Spawning Stars");
            Instantiate(starPrefab, randomPos(-1, 1), Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.X))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
	}

    Vector3 randomPos(float min, float max)
    {
        return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
    }

    void DimUI()
    {
        Title.color = new Color(1, 1, 1, 0.4f);
        Body.color = new Color(1, 1, 1, 0.4f);
    }

    void OnEnable()
    {
        inputItem.OnClick += EndGame;
    }

    void OnDisable()
    {
        inputItem.OnClick -= EndGame;
    }

    void EndGame()
    {
        print("The game has ended.");
        if (targets.Count > 0)
        {
            veryCenter = starCenter.FindCentroid(targets);
        }
        Vector3 direction2Center = (transform.position - veryCenter).normalized;
        constellation = GameObject.FindGameObjectsWithTag("star");
        foreach(GameObject star in constellation)
        {
            if (star.GetComponent<starscript>().wasHit == false)
            {
                Destroy(star);
            }
            else
            {
                star.GetComponent<Renderer>().enabled = false;
                star.GetComponent<starscript>().star2.SetActive(true);
                star.GetComponent<starscript>().star1.SetActive(true);
            }
        }

        camFade.FadeNow(5f,false);
    }
}
