using UnityEngine;

public class StateSoundsToAnimation : MonoBehaviour
{

    public void PlayerMoveSoundToAnimation()
    {
        FindObjectOfType<AudioManager>().Play("Player_Move");
    }

}
