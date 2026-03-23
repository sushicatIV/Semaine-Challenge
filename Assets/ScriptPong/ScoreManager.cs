using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int joueur1 = 0;
    public static int joueur2 = 0;

    public Text texteJoueur1;
    public Text texteJoueur2;

    void Update()
    {
        texteJoueur1.text = joueur1.ToString();
        texteJoueur2.text = joueur2.ToString();
    }
}