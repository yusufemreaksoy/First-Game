using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialController : MonoBehaviour
{

    public TextMeshPro textMesh;
    public string tutorialText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            textMesh.text = tutorialText;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            textMesh.text = null;
        }
    }
}
