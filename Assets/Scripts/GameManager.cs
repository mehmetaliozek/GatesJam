using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IActivator
{
    [SerializeField]
    private List<GameObject> character;

    private int index = 0;

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
            index++;
            if (index == character.Count)
            {
                index = 0;
            }
            Disable();
            Enable();
        }
    }

    public void Enable()
    {
        foreach (var activator in character[index].GetComponents<IActivator>())
        {
            activator.Enable();
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
