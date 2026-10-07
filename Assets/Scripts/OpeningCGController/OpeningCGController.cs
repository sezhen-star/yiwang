using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OpeningCGController : MonoBehaviour
{
    public GameObject CGSpaceShip;
    public GameObject CGTime;

    public GameObject CGCockPit;

    IEnumerator Start()
    {
        CGSpaceShip.SetActive(true);
        CGTime.SetActive(false);
        CGCockPit.SetActive(false);

        yield return new WaitForSeconds(1f);

        CGSpaceShip.SetActive(false);
        CGTime.SetActive(true);

        yield return new WaitForSeconds(1f);

        CGTime.SetActive(false);
        CGCockPit.SetActive(true);
    }

    void Update()
    {
        if (CGCockPit.activeSelf && Input.anyKeyDown)
        {
            SceneManager.LoadScene("Cockpit");
        }
    }
}