using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{   
    /* Public variables */
    public float speed = 1f; // Speed of the score
    public float topOfBackground = 0f; // Upper bound of where notes should spawn

    /* GameObjects */
    public GameObject score; // Parent object for the score
    public GameObject caret; // Caret object to signify where notes are placed
    public GameObject notePrefab; // Note prefab
    public TMPro.TextMeshProUGUI timerText; // Text to display the loop status

    /* Private variables */
    private float elapsedTime = 0f; // Elapsed time since the start of the song
    private Vector3 scoreInitialPos; // Initial position of the score
    private bool firstNoteDrawn = false; // After the first note is drawn, we can start moving the score
    private float loopTime = Mathf.Infinity; // Time it takes for the score to loop

    // Start is called before the first frame update
    void Start()
    {
        scoreInitialPos = score.transform.localPosition;
    }

    private float round(float num) {
        return Mathf.Round(num * 100f) / 100f;
    }

    // Update is called once per frame
    void Update() 
    {
        if (!firstNoteDrawn) {
            return;
        }

        // Get elapsed time
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= loopTime) {
            // Reset the score
            score.transform.localPosition = scoreInitialPos;
            elapsedTime = 0f;
        }

        var scoreDeltaX = Time.deltaTime * speed;
        score.transform.localPosition = new Vector3(score.transform.localPosition.x + scoreDeltaX, score.transform.localPosition.y, score.transform.localPosition.z);
    }

    public void DrawNote(Person person) {
        if (!firstNoteDrawn) {
            firstNoteDrawn = true;
        }

        // Instantiate a new note
        Vector2 pos = new Vector2(caret.transform.localPosition.x - 0.6f, 0);
        GameObject note = Instantiate(notePrefab, caret.transform.localPosition, Quaternion.identity);
        note.transform.parent = score.transform;
        note.GetComponent<SpriteRenderer>().color = person.color;

        // Set the note's Y position
        note.transform.localPosition = new Vector2(note.transform.localPosition.x, person.noteYPos);
    }

    public float GetNoteY(int i) {
        // Get note height
        float buffer = 0.05f;
        float noteHeight = notePrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        // Start at the top of the background
        return topOfBackground - (i * (noteHeight + buffer));
    }

    public void ClearScore() {
        // Destroy all notes
        foreach (Transform child in score.transform) {
            GameObject.Destroy(child.gameObject);
        }

        // Reset the loop time
        loopTime = Mathf.Infinity;
    }

    public void SetLoopTime() {
        this.loopTime = elapsedTime;
    }
}
