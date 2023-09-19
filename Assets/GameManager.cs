using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu_pausa;

    public static bool activado = false;

    //public static String estado = "INICIO";
    // Start is called before the first frame update
    void Start()
    {
        activado = true;
        menu_pausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            menu_pausa.SetActive(true);
            activado = false;
        } 
    }

    public void activarMenu_Pausa()
    {
        menu_pausa.SetActive(false);
        activado = true;
    }
}