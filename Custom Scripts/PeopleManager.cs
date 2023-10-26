using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleManager : MonoBehaviour {

    public ScoreManager scoreManager;

    public PersonDisplay[] people; 
    private Person clickedPerson;

    private void Awake() {
        // Set note Y position for each person -- want them to be separate and not overlapping on spawn
        for (int i = 0; i < people.Length; i++) {
            people[i].person.noteYPos = scoreManager.GetNoteY(i);
        }
    }

    public void Update() {
        // Draw notes if a person is actively being clicked on
        if (clickedPerson) {
            scoreManager.DrawNote(clickedPerson);
        }
    }

    public void setActive(PersonDisplay personDisplay) {
        clickedPerson = personDisplay.person;
    }

    public void unsetActive() {
        clickedPerson = null;
    }

    public void ManageAudio(List<Color> triggerColors) {
        // Play sounds for all colors currently in the trigger now and stop the rest
        for (int i = 0; i < people.Length; i++) {
            PersonDisplay p = people[i];

            if (triggerColors.Contains(p.person.color)) {
                p.PlaySound();
            } else {
                p.StopSound();
            }
        }
    }
}