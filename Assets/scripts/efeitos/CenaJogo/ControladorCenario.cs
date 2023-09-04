using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCenario : MonoBehaviour
{
    public static bool CenarioPausado = false;

    public static void PausarCenario()
    {
        CenarioPausado = true;
    }
}
