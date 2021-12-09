using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Dropdown gameDropdown;
    [SerializeField] TMPro.TMP_Dropdown weatherDropdown;
    [SerializeField] GameObject hideWeatherDropdown;

    int oldHour;
    [SerializeField] int hour;
    string game;
    string weather;

    [SerializeField] AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hour = System.DateTime.Now.Hour;
        
        if(gameDropdown.options[gameDropdown.value].text == "City Folk/Wild World")
        {
            game = "ACCF";
        }else if(gameDropdown.options[gameDropdown.value].text == "New Horizons")
        {
            game = "ACNH";
        }else if(gameDropdown.options[gameDropdown.value].text == "New Leaf")
        {
            game = "ACNL";
        }else if(gameDropdown.options[gameDropdown.value].text == "Population Growing")
        {
            game = "ACPG";
        }

        if (weatherDropdown.options[weatherDropdown.value].text == "Sunny")
        {
            weather = "Normal";
        }
        else if (weatherDropdown.options[weatherDropdown.value].text == "Rainy")
        {
            weather = "Rainy";
        }
        else if (weatherDropdown.options[weatherDropdown.value].text == "Snowy")
        {
            weather = "Snowy";
        }

        if(game == "ACPG")
        {
            hideWeatherDropdown.SetActive(false);
            weather = "Normal";
        }
        else
        {
            hideWeatherDropdown.SetActive(true);
        }

        //System.IO.Directory.GetFiles("Assets/Music/" + game + "/" + weather)[hour].Remove(0, System.IO.Directory.GetFiles("Assets/Music/" + game + "/" + weather)[hour].IndexOf(' ') + 1);
        Debug.Log("Music/" + game + "/" + weather + "/" + game + weather + hour);

        audioClip = Resources.Load<AudioClip>("Music/" + game + "/" + weather + "/" + game + weather + hour);
        gameObject.GetComponent<AudioSource>().clip = audioClip;

        if(gameObject.GetComponent<AudioSource>().enabled != true){
            gameObject.GetComponent<AudioSource>().enabled = true;
        }

        if(oldHour != hour)
        {
            oldHour = hour;
            NewSong();
        }
    }

    public void NewSong()
    {
        gameObject.GetComponent<AudioSource>().enabled = false;
    }
}
