using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager3 gameManager;
    private void OnTriggerEnter(Collider other)
    {
        gameManager.CompleteLevel();
    }
}
