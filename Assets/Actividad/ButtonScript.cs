using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string buttonValue; // El valor del bot�n

    // Este m�todo se llama cuando el proyectil colisiona con el bot�n
    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si el objeto que colision� tiene el componente ProjectileStandard
        if (collision.gameObject.GetComponent<Unity.FPS.Gameplay.ProjectileStandard>())
        {
            // Aqu� puedes agregar cualquier c�digo adicional si quieres realizar algo con el bot�n

            // Destruir el proyectil cuando colisiona
            Destroy(collision.gameObject);

            Debug.Log("Proyectil destruido tras colisionar con el bot�n: " + buttonValue);
        }
    }
}
