using UnityEngine;
using TMPro; // Usar TextMeshPro para pantallas 3D

public class CalculatorManager : MonoBehaviour
{
    public static CalculatorManager Instance;

    // Pantallas de la calculadora
    public TMP_Text screenInput1;  // Para el primer número
    public TMP_Text screenInput2;  // Para el segundo número
    public TMP_Text screenOperator; // Para el operador seleccionado
    public TMP_Text screenResult;   // Para el resultado
    public TMP_Text historyScreen;  // Para el historial de operaciones

    // Variables internas
    private string input1 = "";
    private string input2 = "";
    private string selectedOperator = "";
    private bool isSecondInput = false;
    private string[] history = new string[10]; // Almacenar las últimas 10 operaciones
    private int historyIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void ButtonPressed(string value)
    {
        if (int.TryParse(value, out int number)) // Si el valor es un número
        {
            if (!isSecondInput)
            {
                input1 += value; // Añade el número al primer input
                screenInput1.text = input1; // Muestra el número en la pantalla correspondiente
            }
            else
            {
                input2 += value; // Añade el número al segundo input
                screenInput2.text = input2; // Muestra el número en la pantalla correspondiente
            }
        }
        else if (value == "=") // Si es el botón de igual
        {
            CalculateResult(); // Calcula el resultado
        }
        else // Si es un operador
        {
            selectedOperator = value; // Asigna el operador seleccionado
            screenOperator.text = selectedOperator; // Muestra el operador en la pantalla
            isSecondInput = true; // Cambia para recibir el segundo número
        }
    }

    private void CalculateResult()
    {
        if (input1 == "" || input2 == "" || selectedOperator == "") return; // Si falta algo, no calcula

        float num1 = float.Parse(input1); // Convierte el primer número
        float num2 = float.Parse(input2); // Convierte el segundo número
        float result = 0;

        // Realiza la operación basada en el operador seleccionado
        switch (selectedOperator)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 != 0) result = num1 / num2;
                else screenResult.text = "Error"; // Evitar la división por 0
                break;
        }

        // Muestra el resultado en la pantalla
        screenResult.text = result.ToString();

        // Añade la operación al historial
        AddToHistory(input1 + " " + selectedOperator + " " + input2 + " = " + result);

        // Resetea los valores para la próxima operación
        ResetCalculator();
    }

    private void AddToHistory(string operation)
    {
        // Añade la operación al historial
        history[historyIndex % 10] = operation;
        historyIndex++;

        // Actualiza la pantalla del historial
        historyScreen.text = string.Join("\n", history);
    }

    private void ResetCalculator()
    {
        // Resetea los valores para una nueva operación
        input1 = "";
        input2 = "";
        selectedOperator = "";
        isSecondInput = false;

        // Limpia las pantallas
        screenInput1.text = "";
        screenInput2.text = "";
        screenOperator.text = "";
    }
}
