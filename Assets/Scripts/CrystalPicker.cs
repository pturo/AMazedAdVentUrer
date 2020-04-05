using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrystalPicker : MonoBehaviour
{
    public Text countText;
    public GameObject particles;
    public GameObject winPanel;
    public Text lvlName;

    void Start()
    {
        SetCountText();
	    Scene lvlN = SceneManager.GetActiveScene();
	    lvlName.text = "Poziom: " + lvlN.name; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Crystal"))
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            other.gameObject.SetActive(false);
            SetCountText();
        }
    }

    void SetCountText()
    {
        GameObject[] crystals = GameObject.FindGameObjectsWithTag("Crystal");
        countText = GameObject.Find("CrystalsText").GetComponent<Text>();
        countText.text = "Kryształów: " + crystals.Length;
        if (crystals.Length == 0)
        {
            winPanel.SetActive(true);
	    Time.timeScale = 0f;
            Cursor.visible = true;
        }
    }
}
