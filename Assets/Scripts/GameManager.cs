using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IActivator
{

    [SerializeField]
    private List<GameObject> character;

    private int activePlayer = 0;

    private void Start()
    {
        Disable();
        Enable();
    }

    void Update()
    {
        Activator();
    }

    private void Activator()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            activePlayer++;
            if (activePlayer == character.Count)
            {
                activePlayer = 0;
            }
            Disable();
            Enable();
        }
    }

    public void Enable()
    {
        foreach (var activator in character[activePlayer].GetComponents<IActivator>())
        {
            activator.Enable();
            character[activePlayer].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    public void Disable()
    {
        foreach (var item in character)
        {
            foreach (var activator in item.GetComponents<IActivator>())
            {
                activator.Disable();
            }
        }
    }
}
