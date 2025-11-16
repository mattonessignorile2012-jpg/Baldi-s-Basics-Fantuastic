using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Material[] Skybox;

    private AudioSource Audio;

    public int CollectedNotebooks = 0;

    public int AllNotebooks = 0;

    [SerializeField]
    private TMP_Text NotebooksCounter;

    public AudioClip SchoolMusic;

    public AudioClip FinalModeMusic;

    void Awake()
    {
        RenderSettings.skybox = Skybox[0];
        this.Audio = GetComponent<AudioSource>();
        this.Audio.loop = true;
        this.Audio.clip = SchoolMusic;
        this.Audio.Play();
    }

    void Update()
    {
        Cursor.visible = false;
    }

    void OnCollectNotebook()
    {
        CollectedNotebooks += 1;
        NotebooksCounter.text = CollectedNotebooks + '/' + AllNotebooks + " Notebooks";
        if (CollectedNotebooks == AllNotebooks)
        {
            ActivateFinalMode();
        }
    }

    void ActivateFinalMode()
    {
        RenderSettings.skybox = Skybox[1];
        this.Audio.loop = true;
        this.Audio.clip = FinalModeMusic;
        this.Audio.Play();
    }
}
