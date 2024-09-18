using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string buttonValue;  // El valor del botón que se usará en la calculadora

    // Este método detecta la colisión
    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos que el objeto que impactó el botón tiene el tag "Projectile"
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Botón presionado: " + buttonValue);
            CalculatorManager.Instance.ButtonPressed(buttonValue);
        }
    }
}
