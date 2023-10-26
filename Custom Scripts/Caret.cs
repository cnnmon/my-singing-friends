using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caret : MonoBehaviour
{
    public PeopleManager manager;
    private List<Color> triggerColors = new List<Color>();

    void Update() {
        manager.ManageAudio(triggerColors);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Color color = other.GetComponent<SpriteRenderer>().color;
        triggerColors.Add(color);
    }

    void OnTriggerExit2D(Collider2D other) {
        Color color = other.GetComponent<SpriteRenderer>().color;
        if (triggerColors.Contains(color)) {
            triggerColors.Remove(color);
        }
    }
}
