using UnityEngine;
 
public class Balle : MonoBehaviour
{
    public float vitesse = 5f;
 
    float dirX = 1f;
    float dirY = 1f;
 
    void Update()
    {
        transform.Translate(dirX * vitesse * Time.deltaTime, dirY * vitesse * Time.deltaTime, 0);
 
        if (transform.position.y >= 4.5f || transform.position.y <= -4.5f)
            dirY = -dirY;
 
        if (transform.position.x <= -10.5f)
        {
            ScoreManager.joueur2++;
            ResetBalle();
        }
 
        if (transform.position.x >= 10.5f)
        {
            ScoreManager.joueur1++;
            ResetBalle();
        }
    }
 
    void ResetBalle()
    {
        transform.position = Vector2.zero;
        dirX = -dirX;
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Raquette"))
        {
            dirX = -dirX;
        }
    }
}   
