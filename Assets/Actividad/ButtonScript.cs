using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string buttonValue; // El valor del botón

    // Este método se llama cuando el proyectil colisiona con el botón
    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si el objeto que colisionó tiene el componente ProjectileStandard
        if (collision.gameObject.GetComponent<Unity.FPS.Gameplay.ProjectileStandard>())
        {
            // Aquí puedes agregar cualquier código adicional si quieres realizar algo con el botón

            // Destruir el proyectil cuando colisiona
            Destroy(collision.gameObject);

            Debug.Log("Proyectil destruido tras colisionar con el botón: " + buttonValue);
        }
    }
}
