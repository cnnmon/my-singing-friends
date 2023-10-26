using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Person", menuName = "Person")]
public class Person : ScriptableObject
{
    public Sprite inactive;
    public Sprite active;
    public AudioClip audioClip;
    public Color color;
    public float noteYPos; // Y position of the note on the staff
}
