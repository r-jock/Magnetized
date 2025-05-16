using UnityEngine;

public class coinScript : MonoBehaviour
{
    
    private bool isMagnitized = false;
    public Transform playerTransform;
    public float magnetSpeed = 5f;

    public float minDistance = 0.2f;
    public int coinXp = 15;

    public int coinScore = 1;
    


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MagnetZone"))
        {
            playerTransform = collision.transform.parent;
            isMagnitized = true;

            GameManagerScript.instance.addXp(coinXp);
            GameManagerScript.instance.addScore(coinScore);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isMagnitized && playerTransform != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                playerTransform.position,
                magnetSpeed * Time.deltaTime
            );
            if (Vector2.Distance(transform.position, playerTransform.position) < minDistance)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
