using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrystalPicker : MonoBehaviour
{
    public Text countText;
    public GameObject particles;

    void Start()
    {
        SetCountText();
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.visible = true;
        }
    }
}
